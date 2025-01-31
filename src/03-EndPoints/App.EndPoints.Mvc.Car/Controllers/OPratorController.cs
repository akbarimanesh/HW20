using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.OPrator.AppServices;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using App.EndPoints.Mvc.Car.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class OPratorController : Controller
    {
        private readonly IOPratorAppServices _OPratorAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        private readonly SignInManager<OperatorCar> _signInManager;

        public OPratorController(IOPratorAppServices oPratorAppServices, ICarModelAppServices carModelAppServices, SignInManager<OperatorCar> signInManager)
        {
            _OPratorAppServices = oPratorAppServices;
            _CarModelAppServices = carModelAppServices;
            _signInManager = signInManager;
             
        }
        [HttpGet]
        public async Task<IActionResult> Register(CancellationToken cToken)
        {
           
           var Roles = await _OPratorAppServices.GetRoles(cToken);
            var viewModel = new OpratorCarViewModel
            {
                OperatorCar = new OperatorCar(),
                Roles = Roles
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(OpratorCarViewModel user,CancellationToken cToken)
        {
            await _OPratorAppServices.GetRoles(cToken);
            var result = await _OPratorAppServices.Register(user.OperatorCar , cToken);



            var Roles = await _OPratorAppServices.GetRoles(cToken);
            var viewModel = new OpratorCarViewModel
            {
                OperatorCar = new OperatorCar(),
                Roles = Roles
            };

            //return View(viewModel);
            return RedirectToAction("Login", "OPrator");


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password, CancellationToken cToken)
        {

            var result = await _OPratorAppServices.Login(username, password,cToken);

            return RedirectToAction("Index", "Home");


        }
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            
          
             var Cars =await _OPratorAppServices.GetList(cToken);

             return View("ListCars", Cars);

          
        }
       
        [HttpGet]
        public async Task<IActionResult> Confirmation(int id, CancellationToken cToken)
        {
            
            var result =await _OPratorAppServices.Confirmation(id, cToken);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars = await _OPratorAppServices.GetList(cToken);
            return View("ListCars",Cars);
        }
        [HttpGet]
        public async Task<IActionResult> Rejected(int id, CancellationToken cToken)
        {
            
            var result = await _OPratorAppServices.Rejected(id, cToken);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars =await _OPratorAppServices.GetList(cToken);
            return View("ListCars", Cars);
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
