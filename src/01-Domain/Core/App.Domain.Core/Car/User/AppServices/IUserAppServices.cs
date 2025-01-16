using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.User.AppServices
{
    public interface IUserAppServices
    {
        public Result CreateUserCar(UserCar userCar);
    }
}
