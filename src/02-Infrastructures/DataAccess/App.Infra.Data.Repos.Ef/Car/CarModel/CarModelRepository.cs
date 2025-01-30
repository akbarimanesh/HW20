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

        public async Task<List<Model>> CarModels(CancellationToken cToken)
        {
            return await _appDbContext.Models.AsNoTracking().ToListAsync();
        }

        public async Task CreateModel(Model model, CancellationToken cToken)
        {
           await _appDbContext.Models.AddAsync(model);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteModel(int id, CancellationToken cToken)
        {
            var model =await _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == id);
             _appDbContext.Models.Remove(model);
          await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> GetCModel(string modelTitle, CancellationToken cToken)
        {
            return await _appDbContext.Models.AsNoTracking().AnyAsync(t => t.Title == modelTitle);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cToken)
        {
            return await _appDbContext.Models.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task  UpdateModel(Model model, CancellationToken cToken)
        {
            var model1 =await  _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == model.Id);
           model1.Id = model.Id;
           model1.Title = model.Title;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
