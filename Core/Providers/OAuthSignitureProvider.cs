using Core.Builders;
using Core.Extensions;
using Core.Models.Parameters;
using Core.Validators;

namespace Core.Providers
{
    public class OAuthSignitureProvider
    {
        private readonly OAuthValidator _oAuthValidator;
        private readonly OAuthSignitureBuilder _oAuthSignitureBuilder;
        private readonly HashAlgorithmBuilder _hashAlgorithmBuilder;

        public OAuthSignitureProvider()
        {
            _oAuthValidator = new OAuthValidator();
            _oAuthSignitureBuilder = new OAuthSignitureBuilder();
            _hashAlgorithmBuilder = new HashAlgorithmBuilder();
        }

        public string GetHashEncodedSignitureFor(CallParameters callParameters, string consumerTimeStamp, string nonce)
        {
            _oAuthValidator.ValidateParameters(callParameters, consumerTimeStamp, nonce);

            var oAuthSigniture = _oAuthSignitureBuilder.Build(callParameters, consumerTimeStamp, nonce);
            var hashAlgorithm = _hashAlgorithmBuilder.Build(callParameters.ConsumerSecret, callParameters.TokenSecret);

            _oAuthValidator.ValidateSignitureAndAlgorithm(oAuthSigniture, hashAlgorithm);

            return oAuthSigniture.ToBase64StringUsingHashAlgorithm(hashAlgorithm);
        }
    }
}