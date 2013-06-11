using System.Configuration;
using System.Net.Http;
using Core.Models.Criteria;
using Core.Models.Parameters;

namespace Core.Builders.Criteria
{
    public class RestaurantCriteriaBuilder
    {
        public ICallCriteria Build(RestaurantParameters parameters)
        {
            var url = string.Format("/restaurant/?st=0&pid={0}&rid={1}",
                                       ConfigurationManager.AppSettings["PartnerId"],
                                       parameters.RestaurantId);

            return new RestaurantCallCriteria
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