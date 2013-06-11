using System.Collections.Specialized;
using Core.Models.Parameters;

namespace Core.Models.Criteria
{
    public class CancelCallCriteria : ICallCriteria
    {
        public CancelCallCriteria()
        {
            PostParameters = new NameValueCollection();
        }

        public CallParameters CallParameters { get; set; }
        public NameValueCollection PostParameters { get; set; }
    }
}