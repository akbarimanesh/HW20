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
        public Task<UserCar> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cToken);
        public Task CreateUserCar(UserCar userCar, CancellationToken cToken);
        public Task<bool> GetStatus(string licensePlateCarId, CancellationToken cToken);
        public Task CreateLogUserCar(LogTable logUserCar, CancellationToken cToken);
        
    }
}
