using App.Domain.Core.Car.OPrator.Data.Repositories;
using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.OPrator.Services;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Car.OPrator
{
    public class OPratorServices:IOPratorServices
    {
        private readonly IOPratorRepository _OPratorRepository;

        public OPratorServices(IOPratorRepository oPratorRepository)
        {
            _OPratorRepository = oPratorRepository;
        }

        public void Confirmation(int id)
        {
           _OPratorRepository.Confirmation(id); 
        }

        public UserCar GetById(int id)
        {
            return _OPratorRepository.GetById(id);
        }

        public List<GetListDto> GetList()
        {
           return _OPratorRepository.GetList();
        }

        public OperatorCar Login(string username, string password)
        {
           return  _OPratorRepository.Login(username, password);   
        }

        public void Rejected(int id)
        {
            _OPratorRepository.Rejected(id);
        }
    }
}
