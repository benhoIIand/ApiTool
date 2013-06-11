using System.Web.Mvc;
using Core.Builders.Criteria;
using Core.Builders.ViewModels;
using Core.Models.Parameters;
using Core.ViewModels;

namespace Web.Controllers
{
    public class CancelController : Controller
    {
        private readonly ResponseViewModelBuilder _responseViewModelBuilder;
        private readonly CancelCriteriaBuilder _criteriaBuilder;

        public CancelController()
        {
            _responseViewModelBuilder = new ResponseViewModelBuilder();
            _criteriaBuilder = new CancelCriteriaBuilder();
        }

        public ViewResult Index()
        {
            return View("Index", new ResponseViewModel());
        }

        public ViewResult Invoke(CancelParameters parameters)
        {
            var criteria = _criteriaBuilder.Build(parameters);
            var viewModel = _responseViewModelBuilder.Build(criteria);

            return View("Index", viewModel);
        }
    }
}