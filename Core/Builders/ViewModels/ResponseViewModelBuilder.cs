using System.Linq;
using Core.Models.Criteria;
using Core.ViewModels;

namespace Core.Builders.ViewModels
{
    public class ResponseViewModelBuilder
    {
        private readonly AuthorizationHeaderBuilder _authorizationHeaderBuilder;
        private readonly WebResponseBuilder _webResponseBuilder;

        public ResponseViewModelBuilder()
        {
            _authorizationHeaderBuilder = new AuthorizationHeaderBuilder();
            _webResponseBuilder = new WebResponseBuilder();
        }

        public ResponseViewModel Build(ICallCriteria criteria)
        {
            var authHeader = _authorizationHeaderBuilder.Build(criteria.CallParameters);     
            var responseString = _webResponseBuilder.GetResponseStringFor(criteria, authHeader);

            return new ResponseViewModel
                {
                    PartnerId = criteria.CallParameters.PartnerId,
                    ConsumerKey = criteria.CallParameters.ConsumerKey,
                    ConsumerSecret = criteria.CallParameters.ConsumerSecret, 
                    Url = criteria.CallParameters.Url,
                    Response = responseString,
                    AuthHeaders = authHeader.Value,
                    PostParameters = GetPostParameters(criteria)
                };
        }

        private static string GetPostParameters(ICallCriteria criteria)
        {
            return string.Join("&", criteria.PostParameters
                                                .AllKeys
                                                .Select(key => key + "=" + criteria.PostParameters[key])
                                                .ToArray());
        }
    }
}
