using System.Web.Mvc;
using Core.Builders.Criteria;
using Core.Builders.ViewModels;
using Core.Models.Parameters;
using Core.ViewModels;

namespace Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ResponseViewModelBuilder _responseViewModelBuilder;
        private RestaurantCriteriaBuilder _criteriaBuilder;

        public RestaurantController()
        {
            _responseViewModelBuilder = new ResponseViewModelBuilder();
            _criteriaBuilder = new RestaurantCriteriaBuilder();
        }

        public ViewResult Index()
        {
            return View("Index", new ResponseViewModel());
        }

        public ViewResult Invoke(RestaurantParameters parameters)
        {
            var criteria = _criteriaBuilder.Build(parameters);
            return View("Index", _responseViewModelBuilder.Build(criteria));
        }
    }
}