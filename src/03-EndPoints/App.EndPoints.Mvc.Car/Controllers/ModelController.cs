using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.Car.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ModelController : Controller
    {
        
        private readonly ICarModelAppServices _CarModelAppServices;

        public ModelController(ICarModelAppServices carModelAppServices)
        {
            _CarModelAppServices = carModelAppServices;
        }
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            
            var models =await _CarModelAppServices.CarModels(cToken);
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {

           
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Model model, CancellationToken cToken)
        {
           
            var result = await _CarModelAppServices.CreateModel(model, cToken);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Preview(int id, CancellationToken cToken)
        {
           
            var model = await _CarModelAppServices.GetModelById(id, cToken);



            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cToken)
        {
           
            await _CarModelAppServices.DeleteModel(id, cToken);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cToken)
        {
           
            var model =await _CarModelAppServices.GetModelById(id, cToken);


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Model model, CancellationToken cToken)
        {
           
            var result =await _CarModelAppServices.UpdateModel(model, cToken);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            return View(model);


        }
        
    }
}
