using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class UserCarController : Controller
    {
        private readonly IUserAppServices _UserAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public UserCarController(IUserAppServices userAppServices , ICarModelAppServices carModelAppServices)
        {
            _UserAppServices = userAppServices;
            _CarModelAppServices = carModelAppServices;
        }
        public IActionResult Index()
        {
            var carModels = _CarModelAppServices.CarModels();
            return View(carModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var carModels = _CarModelAppServices.CarModels();
            return View(carModels);
        }
        [HttpPost]
        public IActionResult Create(UserCar userCar)
        {
            var result= _UserAppServices.CreateUserCar(userCar);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            var carModels = _CarModelAppServices.CarModels();
            return View(carModels);

        }

    }
}
