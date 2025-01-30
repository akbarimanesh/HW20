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
       public Task<UserCar> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cToken);
        public Task<bool> GetStatus(string licensePlateCarId, CancellationToken cToken);
        public Task CreateUserCar(UserCar userCar, CancellationToken cToken);
        public Task CreateLogUserCar(LogTable logUserCar, CancellationToken cToken);
       
    }
}
