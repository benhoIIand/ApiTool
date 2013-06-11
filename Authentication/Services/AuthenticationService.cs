using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Authentication.Builders;
using Utilities;

namespace Authentication.Services
{
    public class AuthenticationService
    {
        private OAuthSignitureBuilder _oAuthSignitureBuilder;

        protected const string OAuthConsumerKeyKey = "oauth_consumer_key";
        protected const string OAuthCallbackKey = "oauth_callback";
        protected const string OAuthVersionKey = "oauth_version";
        protected const string OAuthSignatureMethodKey = "oauth_signature_method";
        protected const string OAuthSignatureKey = "oauth_signature";
        protected const string OAuthTimestampKey = "oauth_timestamp";
        protected const string OAuthNonceKey = "oauth_nonce";
        protected const string OAuthTokenKey = "oauth_token";
        protected const string OAuthTokenSecretKey = "oauth_token_secret";
        protected const string OAuthVersion = "1.0";
        protected const string OAuthParameterPrefix = "oauth_";

        public AuthenticationService()
        {
            _oAuthSignitureBuilder = new OAuthSignitureBuilder();
        }

        public string GetAuthorizationHeader(string url)
        {
            string sConsumerKey = "toptableiPadApp";
            string sConsumerSecret = "0201d1060483f376ff";
            string sMethod = "GET";

            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string sConsumerTimestamp = Convert.ToInt64(ts.TotalSeconds).ToString(CultureInfo.InvariantCulture);
            string sConsumerNonce = new Random().Next(123400, 9999999).ToString(CultureInfo.InvariantCulture);

            var oUri = new Uri(url);

            var sComputedSignatureEncoded = _oAuthSignitureBuilder.Build(
                    oUri, sConsumerKey, sConsumerSecret,
                    string.Empty, string.Empty, sMethod,
                    sConsumerTimestamp, sConsumerNonce
                    ).UrlEncode();

            return
                string.Format(
                    "OAuth realm=\"http://www.opentable.com/, oauth_consumer_key=\"{0}\", oauth_signature_method=\"HMAC-SHA1\", oauth_signature=\"{1}\", oauth_timestamp=\"{2}\", oauth_token=\"\", oauth_nonce=\"{3}\", oauth_version=\"1.0\"",
                    sConsumerKey, sComputedSignatureEncoded, sConsumerTimestamp, sConsumerNonce);
        }
        
        protected string NormalizeRequestParameters(IList<QueryParameter> parameters)
        {
            var sb = new StringBuilder();
            QueryParameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        protected List<QueryParameter> GetQueryParameters(string parameters)
        {
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }

            var result = new List<QueryParameter>();

            if (!string.IsNullOrEmpty(parameters))
            {
                string[] p = parameters.Split('&');
                foreach (string s in p)
                {
                    if (!string.IsNullOrEmpty(s) && !s.StartsWith(OAuthParameterPrefix))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(new QueryParameter(temp[0], temp[1]));
                        }
                        else
                        {
                            result.Add(new QueryParameter(s, string.Empty));
                        }
                    }
                }
            }

            return result;
        }
    }
}