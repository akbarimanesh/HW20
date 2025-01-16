using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.User.Entities
{
    public class LogTable
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string LicensePlateCar { get; set; }
        public int YearOfProduction { get; set; }
        public string Address { get; set; }
        public DateTime TechnicalInspection { get; set; }
        public UserBrandCarEnum BrandCar { get; set; }
        public UserStatusCarEnum Status { get; set; } = UserStatusCarEnum.apending;
        public DateTime LoggedAt { get; set; }
        public int ModelId { get; set; }
        #endregion
        #region NavigationProperties
        public Model Model { get; set; }
        #endregion
    }
}
