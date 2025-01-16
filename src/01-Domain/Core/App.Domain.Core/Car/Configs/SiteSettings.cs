using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.Configs
{
    public class SiteSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Limitation  Limitation { get; set; } 
    }
}
