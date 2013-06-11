using System;
using System.Security.Cryptography;
using Core.Models;
using Core.Models.Parameters;

namespace Core.Validators
{
    public class OAuthValidator
    {
        public void ValidateParameters(CallParameters parameters, string consumerTimeStamp, string consumerNonce)
        {
            if (string.IsNullOrEmpty(parameters.ConsumerKey))
            {
                ThrowAuthenticationException("Consumer Key must be provided");
            }

            if (string.IsNullOrEmpty(parameters.ConsumerSecret))
            {
                ThrowAuthenticationException("Consumer Secret must be provided");
            }

            if (parameters.HttpMethod == null)
            {
                ThrowAuthenticationException("Http Method must be provided");
            }

            if (string.IsNullOrEmpty(parameters.Url))
            {
                ThrowAuthenticationException("Url must be provided");
            }

            if (string.IsNullOrEmpty(consumerTimeStamp))
            {
                ThrowAuthenticationException("Consumer timestamp must be provided");
            }

            if (string.IsNullOrEmpty(consumerNonce))
            {
                ThrowAuthenticationException("Consumer nonce must be provided");
            }
        }

        public void ValidateSignitureAndAlgorithm(OAuthSigniture signiture, HMACSHA1 hashAlgorithm)
        {
            if (signiture == null || string.IsNullOrEmpty(signiture.Value))
            {
                ThrowAuthenticationException("Signiture must be provided");
            }

            if (hashAlgorithm == null)
            {
                ThrowAuthenticationException("Hash algorithm must be provided");
            }
        }

        private void ThrowAuthenticationException(string message)
        {
            throw new Exception(string.Format("Exception was thrown validating authentication - {0}", message));
        }
    }
}