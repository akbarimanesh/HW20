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

        public async Task Confirmation(int id, CancellationToken cToken)
        {
          await _OPratorRepository.Confirmation(id, cToken); 
        }

        public async Task<UserCar> GetById(int id, CancellationToken cToken)
        {
            return await _OPratorRepository.GetById(id, cToken);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cToken)
        {
           return  await _OPratorRepository.GetList(cToken);
        }

        public async Task<OperatorCar> Login(string username, string password, CancellationToken cToken)
        {
           return  await _OPratorRepository.Login(username, password,cToken);   
        }

        public async Task Rejected(int id, CancellationToken cToken)
        {
           await _OPratorRepository.Rejected(id, cToken);
        }

        public async Task<List<Role>> GetRoles(CancellationToken cToken)
        {
           return await _OPratorRepository.GetRoles(cToken);
        }
    }
}
