using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.Configs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.EndPoints.Api.Car.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController:ControllerBase
    {
        private readonly ICarModelAppServices _CarModelAppServices;
    

       
        public ModelController(ICarModelAppServices carModelAppServices )
        {
            _CarModelAppServices = carModelAppServices;
           
        }
        [HttpGet("[action]")]
        public async  Task<List<Model>> GetAll(CancellationToken cToken)
        {  
            List<Model> models =await _CarModelAppServices.CarModels(cToken);
            return models;
           
        }
        [HttpGet("[action]")]
        public async Task<Model> GetById(int id, CancellationToken cToken)
        {
            Model model =await _CarModelAppServices.GetModelById(id,cToken);
            return model;

        }
        [HttpPost("[action]")]
        public async Task<string> Create(Model model, CancellationToken cToken)
        {
            var result=await _CarModelAppServices.CreateModel(model,cToken);
            if (result.IsSuccess)
            {

                return result.IsMessage;


            }
            else
            {
                return result.IsMessage;

            }
        }

        [HttpPost("[action]")]
        public async Task<string>  Update(Model model, CancellationToken cToken)
        {
          var result=await _CarModelAppServices.UpdateModel(model,cToken);
            if (result.IsSuccess)
            {
                return result.IsMessage;

            }
            else
            {
                return result.IsMessage;

            }
        }

        [HttpDelete("[action]")]
        public async Task<bool> Delete(int id, CancellationToken cToken)
        {
           await _CarModelAppServices.DeleteModel(id, cToken);
           
            return true;
        }
    }
}
