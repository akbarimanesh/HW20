using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.User.Services
{
    public interface IUserServices
    {
        public UserCar GetByLicensePlateCar(string licensePlateCarId);
        public void CreateUserCar(UserCar userCar);
        public bool GetStatus(string licensePlateCarId);
        public void CreateLogUserCar(LogTable logUserCar);
        
    }
}
