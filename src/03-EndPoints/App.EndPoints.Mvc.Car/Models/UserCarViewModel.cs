using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.User.Entities;
using App.EndPoints.Mvc.Car.Controllers;

namespace App.EndPoints.Mvc.Car.Models
{
    public class UserCarViewModel
    {
        public UserCar CarModel { get; set; }
        public List<Model>? Models { get; set; }
    }
}
