using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Builders
{
    public class OAuthSignitureBuilder
    {
        public string Build(Uri url, string consumerKey, string consumerSecret, string token,
                                         string tokenSecret, string httpMethod, string timeStamp, string nonce)
        {
            string signatureBase = GenerateSignatureBase(url, consumerKey, token, tokenSecret, httpMethod,
                                                         timeStamp, nonce);

            var hmacsha1 = new HMACSHA1();
            hmacsha1.Key =
                Encoding.UTF8.GetBytes(string.Format("{0}&{1}", UrlEncode(consumerSecret),
                                                     string.IsNullOrEmpty(tokenSecret)
                                                         ? ""
                                                         : UrlEncode(tokenSecret)));

            return GenerateSignatureUsingHash(signatureBase, hmacsha1);
        }

        private string GenerateSignatureUsingHash(string data, HashAlgorithm hashAlgorithm)
        {
            if (hashAlgorithm == null)
            {
                throw new ArgumentNullException("hashAlgorithm");
            }

            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("data");
            }

            byte[] dataBuffer = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = hashAlgorithm.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }

        private string GenerateSignatureBase(Uri url, string consumerKey, string token, string tokenSecret,
                                             string httpMethod, string timeStamp, string nonce)
        {
            if (token == null)
            {
                token = string.Empty;
            }

            if (string.IsNullOrEmpty(consumerKey))
            {
                throw new ArgumentNullException("consumerKey");
            }

            if (string.IsNullOrEmpty(httpMethod))
            {
                throw new ArgumentNullException("httpMethod");
            }

            List<QueryParameter> parameters = GetQueryParameters(url.Query);
            parameters.Add(new QueryParameter(OAuthVersionKey, OAuthVersion));
            parameters.Add(new QueryParameter(OAuthNonceKey, nonce));
            parameters.Add(new QueryParameter(OAuthTimestampKey, timeStamp));
            parameters.Add(new QueryParameter(OAuthSignatureMethodKey, "HMAC-SHA1"));
            parameters.Add(new QueryParameter(OAuthConsumerKeyKey, consumerKey));

            // Per section 9.1.1 of the OAuth spec, always include the OAuthToken, even if its value is empty.
            //if (!string.IsNullOrEmpty(token)) {
            parameters.Add(new QueryParameter(OAuthTokenKey, token));
            //}

            parameters.Sort(new QueryParameterComparer());

            normalizedUrl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                normalizedUrl += ":" + url.Port;
            }
            normalizedUrl += url.AbsolutePath;
            normalizedRequestParameters = NormalizeRequestParameters(parameters);

            var signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}&", httpMethod.ToUpper());
            signatureBase.AppendFormat("{0}&", UrlEncode(normalizedUrl));
            signatureBase.AppendFormat("{0}", UrlEncode(normalizedRequestParameters));

            return signatureBase.ToString();
        }
    }
}