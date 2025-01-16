using App.Domain.Core.Car.User.Data.Repositories;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Car.User
{
    public class UserServices:IUserServices
    {
        private readonly IUserRepository _UserRepository;

        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public void CreateLogUserCar(LogTable logUserCar)
        {
            _UserRepository.CreateLogUserCar(logUserCar);
        }

        public void CreateUserCar(UserCar userCar)
        {
            _UserRepository.CreateUserCar(userCar);
        }

        public UserCar GetByLicensePlateCar(string licensePlateCarId)
        {
            return _UserRepository.GetByLicensePlateCar(licensePlateCarId);
        }

        public bool GetStatus(string licensePlateCarId)
        {
            return _UserRepository.GetStatus(licensePlateCarId);
        }
    }
}
