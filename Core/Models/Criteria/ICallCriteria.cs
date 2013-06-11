using System.Collections.Specialized;
using Core.Models.Parameters;

namespace Core.Models.Criteria
{
    public interface ICallCriteria
    {
        CallParameters CallParameters { get; set; }
        NameValueCollection PostParameters { get; set; }
    }
}