using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Enums;
using App.EndPoints.Mvc.Car.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class UserCarController : Controller
    {
        private readonly IUserAppServices _UserAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public UserCarController(IUserAppServices userAppServices, ICarModelAppServices carModelAppServices)
        {
            _UserAppServices = userAppServices;
            _CarModelAppServices = carModelAppServices;
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            var models = _CarModelAppServices.CarModels();


            var viewModel = new UserCarViewModel
            {
                CarModel = new UserCar(),
                Models = models
            };

            return View(viewModel);


        }
        [HttpPost]
        public IActionResult Create(UserCarViewModel model)
        {

           
            if (ModelState.IsValid)
            {
               
                var result = _UserAppServices.CreateUserCar(model.CarModel);
                if (result.IsSuccess)
                {
                    ViewBag.SuccessMessage = result.IsMessage;

                }
                else
                {
                    ViewBag.ErrorMessage = result.IsMessage;
                }


            }
            
          

            var models = _CarModelAppServices.CarModels();
            var viewModel = new UserCarViewModel
            {
                CarModel = new UserCar(),
                Models = models
            };

            return View(viewModel);

        }

    }
}