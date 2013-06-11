using System.Web.Mvc;
using Core.Builders.Criteria;
using Core.Builders.ViewModels;
using Core.Models.Parameters;
using Core.ViewModels;

namespace Web.Controllers
{
    public class TableController : Controller
    {
        private readonly ResponseViewModelBuilder _responseViewModelBuilder;
        private readonly TableCriteriaBuilder _criteriaBuilder;

        public TableController()
        {
            _responseViewModelBuilder = new ResponseViewModelBuilder();
            _criteriaBuilder = new TableCriteriaBuilder();
        }

        public ViewResult Index()
        {
            return View("Index", new ResponseViewModel());
        }

        public ViewResult Invoke(TableParameters parameters)
        {
            var criteria = _criteriaBuilder.Build(parameters);
            return View("Index", _responseViewModelBuilder.Build(criteria));
        }
    }
}