using System.Collections.Specialized;
using Core.Models.Parameters;

namespace Core.Models.Criteria
{
    public class TableCallCriteria : ICallCriteria
    {
        public TableCallCriteria()
        {
            PostParameters = new NameValueCollection();
        }

        public CallParameters CallParameters { get; set; }
        public NameValueCollection PostParameters { get; set; }
    }
}