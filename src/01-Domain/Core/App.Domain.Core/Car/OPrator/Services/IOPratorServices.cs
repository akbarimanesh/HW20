using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.OPrator.Services
{
    public interface IOPratorServices
    {
        public OperatorCar Login(string username, string password);
        public List<GetListDto> GetList();
        public UserCar GetById(int id);
        public void Confirmation(int id);
        public void Rejected(int id);
    }
}
