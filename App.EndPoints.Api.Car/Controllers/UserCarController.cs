using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Entities;
using App.EndPoints.Mvc.Car.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Car.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserCarController : ControllerBase
    {
        private readonly IUserAppServices _UserAppServices;
       // private readonly ICarModelAppServices _CarModelAppServices;
        public UserCarController(IUserAppServices userAppServices)
        {
            _UserAppServices = userAppServices;
           // _CarModelAppServices = carModelAppServices;
        }
        [HttpPost("[action]")]
        public string Create(UserCar model)
        {

            var result=_UserAppServices.CreateUserCar(model);
            if (result.IsSuccess)
            {
               
                return result.IsMessage;
               

            }
            else
            {
                return result.IsMessage;

            }
           

        }
    }
}
