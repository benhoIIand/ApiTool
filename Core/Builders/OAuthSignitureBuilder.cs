using System.Text;
using Core.Extensions;
using Core.Models;
using Core.Models.Parameters;

namespace Core.Builders
{
    public class OAuthSignitureBuilder
    {
        private readonly QueryParameterBuilder _queryParameterBuilder;

        public OAuthSignitureBuilder()
        {
            _queryParameterBuilder = new QueryParameterBuilder();
        }

        public OAuthSigniture Build(CallParameters callParameters, string consumerTimeStamp, string nonce)
        {
            var queryParameters = _queryParameterBuilder.Build(callParameters, consumerTimeStamp, nonce);
            var normalizedUrl = callParameters.Url.ToNormalizedUrl();
            var normalizedRequestParameters = queryParameters.ToNormalizedRequestParameters();

            var oAuthSignitureValue = new StringBuilder();
            oAuthSignitureValue.AppendFormat("{0}&", callParameters.HttpMethod.ToString().ToUpper());
            oAuthSignitureValue.AppendFormat("{0}&", normalizedUrl.UrlEncode());
            oAuthSignitureValue.AppendFormat("{0}", normalizedRequestParameters.UrlEncode());

            return new OAuthSigniture { Value = oAuthSignitureValue.ToString() };
        }
    }
}