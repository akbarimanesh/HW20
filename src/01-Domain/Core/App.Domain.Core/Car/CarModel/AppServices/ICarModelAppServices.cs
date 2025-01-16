using App.Domain.Core.Car.CarModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.CarModel.AppServices
{
    public interface ICarModelAppServices
    {
        public List<Model> CarModels();
        public Result CreateModel(Model model);
        public Model GetModelById(int id);
        public void DeleteModel(int id);
        public Result UpdateModel(Model model);
    }
}
