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

        public void Confirmation(int id)
        {
          var car=  _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefault();
            car.Status = UserStatusCarEnum.aproved;
            _appDbContext.SaveChanges();
        }

        public UserCar GetById(int id)
        {
            return _appDbContext.UserCars.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<GetListDto> GetList()
        {
            return _appDbContext.UserCars.AsNoTracking().OrderBy(x=>x.TechnicalInspection)
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

                }).ToList();
        }

        public OperatorCar Login(string username, string password)
        {
            return _appDbContext.OperatorCars.AsNoTracking().FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public void Rejected(int id)
        {
            var car = _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefault();
            car.Status = UserStatusCarEnum.Rejected;
            _appDbContext.SaveChanges();
        }
    }
}
