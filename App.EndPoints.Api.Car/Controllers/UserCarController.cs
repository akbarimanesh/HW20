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
       
        public UserCarController(IUserAppServices userAppServices)
        {
            _UserAppServices = userAppServices;
          
        }
        [HttpPost("[action]")]
        public async Task<string> Create(UserCar model, CancellationToken cToken)
        {

            var result=await _UserAppServices.CreateUserCar(model,cToken);
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
