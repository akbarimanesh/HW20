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

        public  UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task CreateLogUserCar(LogTable logUserCar, CancellationToken cToken)
        {
           await _UserRepository.CreateLogUserCar(logUserCar, cToken);
        }

        public async Task CreateUserCar(UserCar userCar, CancellationToken cToken)
        {
            await _UserRepository.CreateUserCar(userCar, cToken);
        }

        public async Task<UserCar> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cToken)
        {
            return await _UserRepository.GetByLicensePlateCar(licensePlateCarId, cToken);
        }

        public async Task<bool> GetStatus(string licensePlateCarId, CancellationToken cToken)
        {
            return await _UserRepository.GetStatus(licensePlateCarId, cToken);
        }
    }
}
