using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.OPrator.AppServices
{
    public interface IOPratorAppServices
    {
        public Result Login(string username, string password);
        public List<GetListDto> GetList();
        public UserCar GetById(int id);
        public Result Confirmation(int id);
        public Result Rejected(int id);
    }
}
