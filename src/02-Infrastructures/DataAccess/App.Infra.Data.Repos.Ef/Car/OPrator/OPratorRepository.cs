using App.Domain.Core.Car.OPrator.Data.Repositories;
using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Enums;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Car.OPrator
{
    public class OPratorRepository : IOPratorRepository
    {
        private readonly AppDbContext _appDbContext;

        public OPratorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Confirmation(int id, CancellationToken cToken)
        {
          var car=  await _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefaultAsync();
            car.Status = UserStatusCarEnum.aproved;
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<UserCar> GetById(int id, CancellationToken cToken)
        {
            return await _appDbContext.UserCars.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cToken)
        {
            return await _appDbContext.UserCars.AsNoTracking().OrderBy(x=>x.TechnicalInspection)
                .Select(x => new GetListDto()
                {
                    Id= x.Id,
                    TechnicalInspection= x.TechnicalInspection,
                    ModelName = x.Model.Title,
                    BrandCar = x.BrandCar,
                    LicensePlateCar = x.LicensePlateCar,
                    YearOfProduction = x.YearOfProduction,
                    FirstName = x.FirstName,
                    LastName= x.LastName,
                    NationalCode=x.NationalCode,
                    Mobile= x.Mobile,
                    Address= x.Address,
                    Status= x.Status

                }).ToListAsync();
        }

        public async Task<OperatorCar> Login(string username, string password, CancellationToken cToken)
        {
           
           return await _appDbContext.OperatorCars.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username && x.PasswordHash == password);
        }

        public async Task Rejected(int id, CancellationToken cToken)
        {
            var car =await _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefaultAsync();
            car.Status = UserStatusCarEnum.Rejected;
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRoles(CancellationToken cToken)
        {
            return await _appDbContext.Roles.AsNoTracking().ToListAsync();
           

        }
    }
}
