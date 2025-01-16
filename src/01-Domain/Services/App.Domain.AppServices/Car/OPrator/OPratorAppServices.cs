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

        public Result Confirmation(int id)
        {
            _OPratorServices.Confirmation(id);
            return new Result(true, "تایید شد.");
        }

        public UserCar GetById(int id)
        {
          return _OPratorServices.GetById(id);
        }

        public List<GetListDto> GetList()
        {
           return _OPratorServices.GetList();
           
        }

        public Result Login(string username, string password)
        {
           if(_OPratorServices.Login(username, password)==null)
            {
                return new Result(false, "نام کاربری یا رمز عبور اشتباه است.");
                
               
            }
            else
            {
                _OPratorServices.Login(username, password);
                return new Result(true, "خوش آمدید.");

            }
        }

        public Result Rejected(int id)
        {
            _OPratorServices.Rejected(id);
            return new Result(true, "رد شد.");
        }
    }
}
