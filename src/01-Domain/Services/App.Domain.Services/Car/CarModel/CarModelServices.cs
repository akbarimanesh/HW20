using App.Domain.Core.Car.CarModel.Data.Repositories;
using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.CarModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Car.CarModel
{
    public class CarModelServices:ICarModelServices
    {
        ICarModelRepository _CarModelRepository;

        public CarModelServices(ICarModelRepository carModelRepository)
        {
            _CarModelRepository = carModelRepository;
        }

        public List<Model> CarModels()
        {
            return _CarModelRepository.CarModels();
        }

        public void CreateModel(Model model)
        {
            _CarModelRepository.CreateModel(model);
        }

        public void DeleteModel(int id)
        {
            _CarModelRepository.DeleteModel(id);
        }

        public bool GetCModel(string modelTitle)
        {
            return _CarModelRepository.GetCModel(modelTitle);
        }

        public Model GetModelById(int id)
        {
            return _CarModelRepository.GetModelById(id);
        }

        public void UpdateModel(Model model)
        {
            _CarModelRepository.UpdateModel(model);
        }
    }
}
