﻿using App.Domain.Core.Car.OPrator.DTOs;
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
        public Task<Result> Login(string username, string password, CancellationToken cToken);
        public Task<List<GetListDto>> GetList(CancellationToken cToken);
        public Task<UserCar> GetById(int id, CancellationToken cToken);
        public Task<Result> Confirmation(int id, CancellationToken cToken);
        public Task<Result> Rejected(int id, CancellationToken cToken);
    }
}
