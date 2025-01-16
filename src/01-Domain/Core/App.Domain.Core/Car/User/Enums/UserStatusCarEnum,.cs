using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.Car.User.Enums
{
    public enum UserStatusCarEnum
    {
   
        [Display(Name = "معلق")]
        apending = 1,
        [Display(Name = "تایید شده")]
        aproved = 2,
        [Display(Name = " رد شده")]
        Rejected = 3
    }
}

