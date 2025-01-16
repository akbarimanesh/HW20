using App.Domain.Core.Car.CarModel.Data.Repositories;
using App.Domain.Core.Car.CarModel.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Car.CarModel
{
    public class CarModelRepository:ICarModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Model> CarModels()
        {
           return _appDbContext.Models.AsNoTracking().ToList();
        }

        public void CreateModel(Model model)
        {
            _appDbContext.Models.Add(model);
            _appDbContext.SaveChanges();
        }

        public void DeleteModel(int id)
        {
            var model = _appDbContext.Models.FirstOrDefault(x => x.Id == id);
            _appDbContext.Models.Remove(model);
            _appDbContext.SaveChanges();
        }

        public bool GetCModel(string modelTitle)
        {
            return _appDbContext.Models.AsNoTracking().Any(t => t.Title == modelTitle);
        }

        public Model GetModelById(int id)
        {
            return _appDbContext.Models.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateModel(Model model)
        {
            var model1 = _appDbContext.Models.FirstOrDefault(x => x.Id == model.Id);
           model1.Id = model.Id;
           model1.Title = model.Title;
            _appDbContext.SaveChanges();
        }
    }
}
