using System;
using System.Globalization;
using Core.Extensions;
using Core.Models;
using Core.Models.Parameters;
using Core.Providers;

namespace Core.Builders
{
    public class AuthorizationHeaderBuilder
    {
        private readonly OAuthSignitureProvider _oAuthSignitureProvider;

        public AuthorizationHeaderBuilder()
        {
            _oAuthSignitureProvider = new OAuthSignitureProvider();
        }

        public AuthorizationHeader Build(CallParameters parameters)
        {
            var currentUnixTime = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var consumerTimestamp = Convert.ToInt64(currentUnixTime.TotalSeconds).ToString(CultureInfo.InvariantCulture);
            var consumerNonce = new Random().Next(123400, 9999999).ToString(CultureInfo.InvariantCulture);

            var encodedOAuthSigniture = _oAuthSignitureProvider.GetHashEncodedSignitureFor(parameters, consumerTimestamp, consumerNonce).UrlEncode();

            return new AuthorizationHeader
            {
                Value = string.Format(
                    "OAuth realm=\"http://www.opentable.com/, oauth_consumer_key=\"{0}\", oauth_signature_method=\"HMAC-SHA1\", oauth_signature=\"{1}\", oauth_timestamp=\"{2}\", oauth_token=\"\", oauth_nonce=\"{3}\", oauth_version=\"1.0\"",
                    parameters.ConsumerKey, encodedOAuthSigniture, consumerTimestamp, consumerNonce)
            };
        }
    }
}