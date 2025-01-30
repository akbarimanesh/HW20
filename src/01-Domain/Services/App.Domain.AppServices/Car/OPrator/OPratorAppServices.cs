using App.Domain.Core.Car.OPrator.AppServices;
using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.OPrator.Services;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Car.OPrator
{
    public class OPratorAppServices:IOPratorAppServices
    {
        private readonly IOPratorServices _OPratorServices;

        public OPratorAppServices(IOPratorServices oPratorServices)
        {
            _OPratorServices = oPratorServices;
        }

        public async Task<Result> Confirmation(int id, CancellationToken cToken)
        {
           await _OPratorServices.Confirmation(id, cToken);
            return new Result(true, "تایید شد.");
        }

        public async Task<UserCar> GetById(int id, CancellationToken cToken)
        {
          return await _OPratorServices.GetById(id, cToken);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cToken)
        {
           return await _OPratorServices.GetList(cToken);
           
        }

        public async Task<Result> Login(string username, string password, CancellationToken cToken)
        {
           if(await _OPratorServices.Login(username, password,cToken)==null)
            {
                return new Result(false, "نام کاربری یا رمز عبور اشتباه است.");
                
               
            }
            else
            {
               await _OPratorServices.Login(username, password, cToken);
                return new Result(true, "خوش آمدید.");

            }
        }

        public async Task<Result> Rejected(int id, CancellationToken cToken)
        {
           await _OPratorServices.Rejected(id, cToken);
            return new Result(true, "رد شد.");
        }
    }
}
