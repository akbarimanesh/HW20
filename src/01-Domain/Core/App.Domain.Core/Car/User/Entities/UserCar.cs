﻿using App.Domain.Core.Car.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Domain.Core.Car.CarModel.Entities;
using System.ComponentModel.DataAnnotations;
namespace App.Domain.Core.Car.User.Entities
{
    public class UserCar
    {
        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن نام اجباری است")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "وارد کردن نام خانوادگی اجباری است")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "وارد کردن کدملی اجباری است")]
        [StringLength(10, ErrorMessage = "کد ملی 10 رقم است")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره تلفن اجباری است")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نیست. باید با 09 شروع شود و 11 رقم باشد.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره پلاک اجباری است")]
        [StringLength(6, ErrorMessage = "شماره پلاک 5 رقم و یک حرف دارد ")]
        public string LicensePlateCar { get; set; }

        [Required(ErrorMessage = "وارد کردن سال تولید خودرو اجباری است")]
       
        [Range(1900, 2025, ErrorMessage = "سال تولید باید بین 1900 تا 2025 باشد ")]
        public int YearOfProduction { get; set; }

        [Required(ErrorMessage = "وارد کردن آدرس اجباری است")]
        public string Address { get; set; }

        [Required(ErrorMessage = "وارد کردن تاریخ اجباری است")]
        [DataType(DataType.Date, ErrorMessage = "فرمت تاریخ نامعتبر است")]
        public DateTime TechnicalInspection { get; set; }

        [Required(ErrorMessage = "انتخاب برند خودرو اجباری است")]
        public UserBrandCarEnum BrandCar { get; set; }

        public UserStatusCarEnum Status { get; set; } = UserStatusCarEnum.apending;
        [Required(ErrorMessage = "انتخاب مدل خودرو اجباری است")]
        public  int  ModelId { get; set; }
        #endregion

        #region NavigationProperties
      
        public Model? Model { get; set; }
        #endregion
    }
}
