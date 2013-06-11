using System.Web.Mvc;
using Core.Builders.Criteria;
using Core.Builders.ViewModels;
using Core.Models.Parameters;
using Core.ViewModels;

namespace Web.Controllers
{
    public class SlotLockController : Controller
    {
        private readonly ResponseViewModelBuilder _responseViewModelBuilder;
        private readonly SlotLockCriteriaBuilder _criteriaBuilder;

        public SlotLockController()
        {
            _responseViewModelBuilder = new ResponseViewModelBuilder();
            _criteriaBuilder = new SlotLockCriteriaBuilder();
        }

        public ViewResult Index()
        {
            return View("Index", new ResponseViewModel());
        }

        public ViewResult Invoke(SlotLockParameters parameters)
        {
            var criteria = _criteriaBuilder.Build(parameters);
            var viewModel = _responseViewModelBuilder.Build(criteria);

            return View("Index", viewModel);
        }
    }
}