using System.Configuration;
using System.Net.Http;
using Core.Extensions;
using Core.Models.Criteria;
using Core.Models.Parameters;

namespace Core.Builders.Criteria
{
    public class CancelCriteriaBuilder
    {
        public ICallCriteria Build(CancelParameters parameters)
        {
            var url = string.Format("/reservation/?pid={0}&rid={1}&email={2}&conf={3}",
                                    ConfigurationManager.AppSettings["PartnerId"],
                                    parameters.RestaurantId, 
                                    parameters.Email.UrlEncode(), 
                                    parameters.ConfirmationNumber);

            return new CancelCallCriteria
                {
                    CallParameters = new CallParameters
                        {
                            Url = url,
                            HttpMethod = HttpMethod.Get
                        }
                };
        }
    }
}