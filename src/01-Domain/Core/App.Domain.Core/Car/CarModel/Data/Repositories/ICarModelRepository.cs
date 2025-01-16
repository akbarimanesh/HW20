using App.Domain.Core.Car.CarModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Car.CarModel.Data.Repositories
{
    
    public interface ICarModelRepository
    {
        public List<Model> CarModels();
        public void CreateModel(Model model);
        public Model GetModelById(int id);
        public void DeleteModel(int id);
        public void UpdateModel(Model model);
        public bool GetCModel(string modelTitle);

    }
}
