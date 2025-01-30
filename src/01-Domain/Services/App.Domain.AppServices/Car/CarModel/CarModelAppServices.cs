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

        public async Task<List<Model>> CarModels(CancellationToken cToken)
        {
           return await _CarModelServices.CarModels( cToken);
        }

        public async Task<Result> CreateModel(Model model, CancellationToken cToken)
        {
            if (await _CarModelServices.GetCModel(model.Title,cToken))
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
                await _CarModelServices.CreateModel(model1, cToken);
                return new Result(true, "مدل خودرو با موفقیت اضافه شد.");
            }
        }

        public async Task DeleteModel(int id, CancellationToken cToken)
        {
            await _CarModelServices.DeleteModel(id, cToken);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cToken)
        {
            return await _CarModelServices.GetModelById(id, cToken);
        }

        public async Task<Result> UpdateModel(Model model, CancellationToken cToken)
        {
            if (await _CarModelServices.GetCModel(model.Title, cToken))
            {
                return new Result(false, "مدل خودرو موجود می باشد.");

            }

            else
            {
               await _CarModelServices.UpdateModel(model,cToken);
                return new Result(true, "ویرایش با موفقیت انجام شد.");
            }
        }
    }
}
