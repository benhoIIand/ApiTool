using System;
using System.Collections.Generic;
using System.Text;
using Core.Models.Parameters;

namespace Core.Extensions
{
    public static class UrlExtensions   
    {
        public static string UrlEncode(this string value)
        {
            const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

            var result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }

        public static string ToApiQuerystringParameters(this string value)
        {
            var uri = new Uri(value);
            var queryStringParameters = uri.Query;

            if (queryStringParameters.StartsWith("?"))
            {
                queryStringParameters = queryStringParameters.Remove(0, 1);
            }

            return queryStringParameters;
        }

        public static string ToNormalizedUrl(this string url)
        {
            var uri = new Uri(url);
            var outcome = string.Format("{0}://{1}", uri.Scheme, uri.Host);

            if (!((uri.Scheme == "http" && uri.Port == 80) || (uri.Scheme == "https" && uri.Port == 443)))
            {
                outcome += ":" + uri.Port;
            }

            outcome += uri.AbsolutePath;
            return outcome;
        }
    }
}
