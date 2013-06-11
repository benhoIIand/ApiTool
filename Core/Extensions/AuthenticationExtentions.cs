using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Core.Models;
using Core.Models.Parameters;

namespace Core.Extensions
{
    public static class AuthenticationExtentions
    {
        public static string ToNormalizedRequestParameters(this IList<QueryParameter> queryParameters)
        {
            var outcome = new StringBuilder();

            for (int i = 0; i < queryParameters.Count; i++)
            {
                var qp = queryParameters[i];
                outcome.AppendFormat("{0}={1}", qp.Name, qp.Value);

                if (i < queryParameters.Count - 1)
                {
                    outcome.Append("&");
                }
            }

            return outcome.ToString();
        }

        public static string ToBase64StringUsingHashAlgorithm(this OAuthSigniture signiture, HMACSHA1 hashAlgorithm)
        {
            var dataBuffer = Encoding.UTF8.GetBytes(signiture.Value);
            var hashBytes = hashAlgorithm.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }
    }
}