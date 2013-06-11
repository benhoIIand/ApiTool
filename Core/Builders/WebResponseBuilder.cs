using System;
using System.Net;
using System.Text;
using Core.Models;
using Core.Models.Criteria;

namespace Core.Builders
{
    public class WebResponseBuilder
    {
        public string GetResponseStringFor(ICallCriteria criteria, AuthorizationHeader authHeader)
        {
            var responseValue = string.Empty;

            var webClient = new WebClient();
            webClient.Headers.Add("AUTHORIZATION", authHeader.Value);
            
            try
            {
                using (webClient)
                {
                    if (CallHasPostParameters(criteria))
                    {
                        var uploadResponse = webClient.UploadValues(criteria.CallParameters.Url, criteria.PostParameters);
						responseValue = Encoding.ASCII.GetString(uploadResponse);
                    }
                    else
                    {
                        responseValue = webClient.DownloadString(criteria.CallParameters.Url);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get response for url '{0}' - {1}", ex);
            }

            return responseValue;
        }

        private static bool CallHasPostParameters(ICallCriteria criteria)
        {
            return criteria.PostParameters != null && criteria.PostParameters.Count > 0;
        }
    }
}