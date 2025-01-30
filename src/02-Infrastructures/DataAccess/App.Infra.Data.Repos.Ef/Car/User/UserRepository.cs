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

        public async Task CreateLogUserCar(LogTable logUserCar, CancellationToken cToken)
        {
           await _appDbContext.LogTables.AddAsync(logUserCar);
          await  _appDbContext.SaveChangesAsync();
        }

        public async Task CreateUserCar(UserCar userCar, CancellationToken cToken)
        {
           await _appDbContext.UserCars.AddAsync(userCar);
           await _appDbContext.SaveChangesAsync();
            
        }

        public async Task<UserCar> GetByLicensePlateCar(string licensePlateCarId,CancellationToken cToken)
        {
            return await _appDbContext.UserCars.AsNoTracking().FirstOrDefaultAsync(x => x.LicensePlateCar==licensePlateCarId);
        }

        public async Task<bool> GetStatus(string licensePlateCarId, CancellationToken cToken)
        {
            return await _appDbContext.UserCars.AsNoTracking().AnyAsync(x => x.LicensePlateCar == licensePlateCarId && x.Status == UserStatusCarEnum.aproved);
        }
    }
}
