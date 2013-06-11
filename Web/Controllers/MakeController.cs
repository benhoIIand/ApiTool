using System.Web.Mvc;
using Core.Builders.Criteria;
using Core.Builders.ViewModels;
using Core.Models.Parameters;
using Core.ViewModels;

namespace Web.Controllers
{
    public class MakeController : Controller
    {
        private readonly ResponseViewModelBuilder _responseViewModelBuilder;
        private MakeCriteriaBuilder _criteriaBuilder;

        public MakeController()
        {
            _responseViewModelBuilder = new ResponseViewModelBuilder();
            _criteriaBuilder = new MakeCriteriaBuilder();
        }

        public ViewResult Index()
        {
            return View("Index", new ResponseViewModel());
        }

        public ViewResult Invoke(MakeParameters parameters)
        {
            var criteria = _criteriaBuilder.Build(parameters);
            var viewModel = _responseViewModelBuilder.Build(criteria);

            return View("Index", viewModel);
        }
    }
}