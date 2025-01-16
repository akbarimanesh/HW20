using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.CarModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Car.CarModel
{
    public class CarModelAppServices : ICarModelAppServices
    {
        private readonly ICarModelServices _CarModelServices;

        public CarModelAppServices(ICarModelServices carModelServices)
        {
            _CarModelServices = carModelServices;
        }

        public List<Model> CarModels()
        {
           return _CarModelServices.CarModels();
        }

        public Result CreateModel(Model model)
        {
            if (_CarModelServices.GetCModel(model.Title))
            {
                return new Result(false, "مدل خودرو موجود می باشد.");

            }
           
            else
            {
                var model1 = new Model
                {
                    Id = model.Id,
                    Title = model.Title,
                    
                };
                _CarModelServices.CreateModel(model1);
                return new Result(true, "مدل خودرو با موفقیت اضافه شد.");
            }
        }

        public void DeleteModel(int id)
        {
            _CarModelServices.DeleteModel(id);
        }

        public Model GetModelById(int id)
        {
            return _CarModelServices.GetModelById(id);
        }

        public Result UpdateModel(Model model)
        {
            if (_CarModelServices.GetCModel(model.Title))
            {
                return new Result(false, "مدل خودرو موجود می باشد.");

            }

            else
            {
                _CarModelServices.UpdateModel(model);
                return new Result(true, "ویرایش با موفقیت انجام شد.");
            }
        }
    }
}
