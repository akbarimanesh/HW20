using App.Domain.Core.Car.Configs;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.User.Data.Repositories
{
    public interface IUserRepository
    {
       public UserCar GetByLicensePlateCar(string licensePlateCarId);
        public bool GetStatus(string licensePlateCarId);
        public void CreateUserCar(UserCar userCar);
        public void CreateLogUserCar(LogTable logUserCar);
       
    }
}
