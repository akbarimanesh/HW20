using App.Domain.Core.Car.Configs;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Entities;
using App.Domain.Core.Car.User.Enums;
using App.Domain.Core.Car.User.Services;
using App.Infra.Data.Db.SqlServer.Ef;
using Framework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Car.User
{
    public class UserAppServices:IUserAppServices
    {
        private readonly IUserServices _UserServices;
        private readonly SiteSettings _SiteSettings;

       
        public UserAppServices(IUserServices userServices , SiteSettings siteSettings)
        {
            _UserServices = userServices;
            _SiteSettings = siteSettings;
        }

        public async Task<Result> CreateUserCar(UserCar userCar, CancellationToken cToken)
        {
            
           
            if (await _UserServices.GetByLicensePlateCar(userCar.LicensePlateCar,cToken)!=null && await _UserServices.GetStatus(userCar.LicensePlateCar, cToken) && userCar.TechnicalInspection.AddDays(365) >= DateTime.Now)
            {
                return new Result(false, "خودرو شما کمتر از یکسال،معاینه فنی رو دریافت کرده است.");
            }
           if(userCar.YearOfProduction+5<DateTime.Now.Year)
            {
                var log = new LogTable()
                {
                    Id = userCar.Id,
                    FirstName = userCar.FirstName,
                    LastName = userCar.LastName,
                    NationalCode = userCar.NationalCode,
                    Mobile = userCar.Mobile,
                    LicensePlateCar = userCar.LicensePlateCar,
                    YearOfProduction = userCar.YearOfProduction,
                    Address = userCar.Address,
                    TechnicalInspection = userCar.TechnicalInspection,
                    BrandCar = userCar.BrandCar,
                    ModelId = userCar.ModelId,
                    Status = userCar.Status,
                    LoggedAt= DateTime.Now

                };
               await _UserServices.CreateLogUserCar(log, cToken);
                return new Result(false, "سال تولید خودرو شما بیش از 5 سال است.");

            }
           if(userCar.TechnicalInspection.Day%2==0 && userCar.BrandCar!= UserBrandCarEnum.IranKhodro)
            {
                return new Result(false, "در روزهای زوج فقط ایران خودرو رزرو دارد");
            }
            if (userCar.TechnicalInspection.Day % 2 != 0 && userCar.BrandCar != UserBrandCarEnum.Saipa)
            {
                return new Result(false, "در روزهای فرد فقط سایپا رزرو دارد");
            }
            if (userCar.TechnicalInspection.Day % 2 == 0 && MemoryDb.EvenDayRequests >=_SiteSettings.Limitation.Irankhodro )
            {
                return new Result(false, "ظرفیت ایران خودرو به پایان رسیده است.");
            }
            if (userCar.TechnicalInspection.Day % 2 != 0 && MemoryDb.OddDayRequests >= _SiteSettings.Limitation.Saipa)
            {
                return new Result(false, "ظرفیت سایپا به پایان رسیده است.");
            }
            else
            {
                var usercar1 = new UserCar()
                {
                    Id= userCar.Id,
                    FirstName= userCar.FirstName,
                    LastName= userCar.LastName,
                    NationalCode= userCar.NationalCode,
                    Mobile= userCar.Mobile,
                    LicensePlateCar= userCar.LicensePlateCar,
                    YearOfProduction= userCar.YearOfProduction,
                    Address = userCar.Address,
                    TechnicalInspection = userCar.TechnicalInspection,
                    BrandCar = userCar.BrandCar,
                    ModelId=userCar.ModelId,
                    Status= userCar.Status
                   
                };
               await _UserServices.CreateUserCar(usercar1,cToken);
                if(userCar.TechnicalInspection.Day % 2 == 0)
                {
                    MemoryDb.EvenDayRequests++;
                }
               else if (userCar.TechnicalInspection.Day % 2 != 0)
                {
                    MemoryDb.OddDayRequests++;
                }
                return new Result(true, "تاریخ معاینه فنی خودرو شما با موفقیت ثبت شد.");
            }
        }

        
    }
}
