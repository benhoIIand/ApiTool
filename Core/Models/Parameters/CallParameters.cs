using System.Configuration;
using System.Net.Http;

namespace Core.Models.Parameters
{
    public class CallParameters
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = string.Format("https://www.toptable.co.uk/api/v3.ashx{0}", value); }
        }
        
        public HttpMethod HttpMethod { get; set; }
        
        public string PartnerId { get { return ConfigurationManager.AppSettings["PartnerId"]; } }
        public string RestaurantId { get { return ConfigurationManager.AppSettings["RestaurantId"]; } }
        public string ConsumerKey { get { return ConfigurationManager.AppSettings["ConsumerKey"]; } }
        public string ConsumerSecret { get { return ConfigurationManager.AppSettings["ConsumerSecret"]; } }
        public string Token { get { return string.Empty; } }
        public string TokenSecret { get { return string.Empty; } }

        public string DateTime { get; set; }
        public string PartySize { get; set; }
        public string TimeSecurityId { get; set; }
        public string ResultsKey { get; set; }
    }
}