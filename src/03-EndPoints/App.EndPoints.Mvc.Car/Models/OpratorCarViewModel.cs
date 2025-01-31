using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;

namespace App.EndPoints.Mvc.Car.Models
{
    public class OpratorCarViewModel
    {
        public OperatorCar OperatorCar {  get; set; }

        public List<Role> Roles { get; set; }
    }
}
