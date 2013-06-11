using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using Core.Extensions;
using Core.Models.Criteria;
using Core.Models.Parameters;

namespace Core.Builders.Criteria
{
    public class SlotLockCriteriaBuilder
    {
        public ICallCriteria Build(SlotLockParameters parameters)
        {
            var url = string.Format("/slotlock/?st=0&pid={0}",
                                        ConfigurationManager.AppSettings["PartnerId"]);

            return new SlotLockCallCriteria
                {
                    CallParameters = new CallParameters
                        {
                            DateTime = parameters.DateTime.ToApiDateTimeFormat(),
                            PartySize = "2",
                            Url = url,
                            HttpMethod = HttpMethod.Post
                        },
                    PostParameters = new NameValueCollection
                        {
                            {"rid", parameters.RestaurantId.ToString(CultureInfo.InvariantCulture)},
                            {"datetime", parameters.DateTime.ToApiDateTimeFormat()},
                            {"partysize", parameters.PartySize.ToString(CultureInfo.InvariantCulture)},
                            {"timesecurityID", parameters.SecurityId},
                            {"resultskey", parameters.ResultsKey}
                        }
                };

        }
    }
}