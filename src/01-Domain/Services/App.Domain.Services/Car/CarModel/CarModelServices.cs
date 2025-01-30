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

        public async Task<List<Model>> CarModels(CancellationToken cToken)
        {
            return await _CarModelRepository.CarModels(cToken);
        }

        public async Task CreateModel(Model model, CancellationToken cToken)
        {
           await _CarModelRepository.CreateModel(model, cToken);
        }

        public async Task DeleteModel(int id, CancellationToken cToken)
        {
            await _CarModelRepository.DeleteModel(id, cToken);
        }

        public async Task<bool> GetCModel(string modelTitle, CancellationToken cToken)
        {
            return await _CarModelRepository.GetCModel(modelTitle, cToken);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cToken)
        {
            return await _CarModelRepository.GetModelById(id, cToken);
        }

        public async Task UpdateModel(Model model, CancellationToken cToken)
        {
           await _CarModelRepository.UpdateModel(model, cToken);
        }
    }
}
