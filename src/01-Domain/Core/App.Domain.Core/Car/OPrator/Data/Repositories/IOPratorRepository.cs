using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.OPrator.Data.Repositories
{
    public interface IOPratorRepository
    {
        public Task<List<Role>> GetRoles(CancellationToken cToken);
        public Task<OperatorCar> Login(string username, string password, CancellationToken cToken);
        public Task<List<GetListDto>> GetList(CancellationToken cToken);
        public Task<UserCar> GetById(int id, CancellationToken cToken);
        public Task Confirmation(int id, CancellationToken cToken);
        public Task Rejected(int id, CancellationToken cToken);
    }
}
