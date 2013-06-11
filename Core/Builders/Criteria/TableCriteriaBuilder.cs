using System.Configuration;
using System.Net.Http;
using Core.Extensions;
using Core.Models.Criteria;
using Core.Models.Parameters;

namespace Core.Builders.Criteria
{
    public class TableCriteriaBuilder
    {
        public ICallCriteria Build(TableParameters parameters)
        {
           var url = string.Format("/table/?st=0&pid={0}&rid={1}&dt={2}&ps={3}",
                                    ConfigurationManager.AppSettings["PartnerId"],
                                    parameters.RestaurantId,
                                    parameters.DateTime.ToApiDateTimeFormat().UrlEncode(),
                                    parameters.PartySize);

            return new TableCallCriteria
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