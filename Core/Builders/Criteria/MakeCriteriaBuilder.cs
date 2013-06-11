using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using Core.Extensions;
using Core.Models.Criteria;
using Core.Models.Parameters;

namespace Core.Builders.Criteria
{
    public class MakeCriteriaBuilder
    {
        public ICallCriteria Build(MakeParameters parameters)
        {
            var url = string.Format("/reservation/?pid={0}&st=0",
                                   ConfigurationManager.AppSettings["PartnerId"]);

            return new MakeCallCriteria
            {
                CallParameters = new CallParameters
                {
                    DateTime = parameters.DateTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    PartySize = parameters.PartySize.ToString(CultureInfo.InvariantCulture),
                    Url = url,
                    HttpMethod = HttpMethod.Post
                },
                PostParameters = new NameValueCollection
                        {
                            {"email_address", parameters.Email},
                            {"RID", parameters.RestaurantId.ToString(CultureInfo.InvariantCulture)},
                            {"datetime", parameters.DateTime.ToApiDateTimeFormat()},
                            {"partysize", parameters.PartySize.ToString(CultureInfo.InvariantCulture)},
                            {"phone", "02012345678"},
                            {"OTannouncementOption", "0"},
                            {"RestaurantEmailOption", "0"},
                            {"firstname", "John"},
                            {"lastname", "Smith"},
                            {"timesecurityID", parameters.SecurityId},
                            {"resultskey", parameters.ResultsKey},
                            {"firsttimediner", "0"},
                            {"specialinstructions", string.Empty},
                            {"authkey", string.Empty},
                            {"points", "0"},
                            {"app_version", string.Empty},
                            {"slotlockid", parameters.SlotLockId.ToString(CultureInfo.InvariantCulture)},
                            {"cclast4", string.Empty},
                            {"cccustuuid", string.Empty},
                            {"ccpmtuuid", string.Empty},
                            {"cchttpstat", string.Empty},
                            {"ccresphash", string.Empty},
                            {"ccresptime", string.Empty},
                            {"phcountrycode", "UK"},
                            {"offerid", parameters.OfferId.ToString(CultureInfo.InvariantCulture)},
					        {"offertitle", parameters.OfferTitle},
                            {"restrefid", string.Empty}
                        }
            };
        }
    }
}