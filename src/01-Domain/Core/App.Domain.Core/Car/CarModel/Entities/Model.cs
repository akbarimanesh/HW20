using App.Domain.Core.Car.User.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.CarModel.Entities
{
    public class Model
    {
        #region Properties
        public int Id { get; set; }
        [Required(ErrorMessage = "انتخاب مدل خودرو اجباری است")]
        public string Title { get; set; }

        #endregion
        #region NavigationProperties
        public List<UserCar> usercars { get; set; }   
        #endregion
    }
}
