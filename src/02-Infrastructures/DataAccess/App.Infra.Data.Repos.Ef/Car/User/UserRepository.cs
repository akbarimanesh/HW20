using App.Domain.Core.Car.Configs;
using App.Domain.Core.Car.User.Data.Repositories;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Enums;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
namespace App.Infra.Data.Repos.Ef.Car.User
{
    public class UserRepository : IUserRepository
    {
       private readonly AppDbContext _appDbContext;
        private readonly SiteSettings _SiteSettings;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateLogUserCar(LogTable logUserCar)
        {
            _appDbContext.LogTables.Add(logUserCar);
            _appDbContext.SaveChanges();
        }

        public void CreateUserCar(UserCar userCar)
        {
            _appDbContext.UserCars.Add(userCar);
            _appDbContext.SaveChanges();
            
        }

        public UserCar GetByLicensePlateCar(string licensePlateCarId)
        {
            return _appDbContext.UserCars.AsNoTracking().FirstOrDefault(x => x.LicensePlateCar==licensePlateCarId);
        }

        public bool GetStatus(string licensePlateCarId)
        {
            return _appDbContext.UserCars.AsNoTracking().Any(x => x.LicensePlateCar == licensePlateCarId && x.Status == UserStatusCarEnum.aproved);
        }
    }
}
