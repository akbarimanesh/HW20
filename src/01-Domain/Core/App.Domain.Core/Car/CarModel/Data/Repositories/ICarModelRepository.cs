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
        public  Task<List<Model>> CarModels(CancellationToken cToken);
        public  Task CreateModel(Model model, CancellationToken cToken);
        public  Task<Model> GetModelById(int id, CancellationToken cToken);
        public  Task DeleteModel(int id, CancellationToken cToken);
        public  Task UpdateModel(Model model, CancellationToken cToken);
        public  Task<bool> GetCModel(string modelTitle, CancellationToken cToken);

    }
}
