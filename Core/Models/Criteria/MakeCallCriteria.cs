using System.Collections.Specialized;
using Core.Models.Parameters;

namespace Core.Models.Criteria
{
    public class MakeCallCriteria : ICallCriteria
    {
        public CallParameters CallParameters { get; set; }
        public NameValueCollection PostParameters { get; set; }
    }
}