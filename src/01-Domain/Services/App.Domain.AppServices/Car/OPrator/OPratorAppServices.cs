using App.Domain.Core.Car.OPrator.AppServices;
using App.Domain.Core.Car.OPrator.DTOs;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.OPrator.Services;
using App.Domain.Core.Car.User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Car.OPrator
{
    public class OPratorAppServices:IOPratorAppServices
    {
        private readonly IOPratorServices _OPratorServices;
        private readonly UserManager<OperatorCar> _userManager;
        private readonly SignInManager<OperatorCar> _signInManager;
      //  private readonly RoleManager<IdentityRole> _roleManager;
        public OPratorAppServices(IOPratorServices oPratorServices , UserManager<OperatorCar> userManager, SignInManager<OperatorCar> signInManager)
        {
            _OPratorServices = oPratorServices;
            _userManager = userManager;
            _signInManager = signInManager;
           //_roleManager = roleManager;
        }
        public async Task<IdentityResult> Register(OperatorCar model, CancellationToken cToken)
        {
            var user = new OperatorCar
            {
                UserName = model.UserName,
                Email = model.Email,
               

            };
             
           
            var result = await _userManager.CreateAsync(user, "123456");

            if (result.Succeeded)
            {
                //await _userManager.GetRolesAsync(user);
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return result;
        }
        public async Task<Result> Confirmation(int id, CancellationToken cToken)
        {
           await _OPratorServices.Confirmation(id, cToken);
            return new Result(true, "تایید شد.");
        }
        public async Task<Result> Rejected(int id, CancellationToken cToken)
        {
            await _OPratorServices.Rejected(id, cToken);
            return new Result(true, "رد شد.");
        }
        public async Task<UserCar> GetById(int id, CancellationToken cToken)
        {
          return await _OPratorServices.GetById(id, cToken);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cToken)
        {
           return await _OPratorServices.GetList(cToken);
           
        }

        public async Task<IdentityResult> Login(string username, string password, CancellationToken cToken)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
        //public async Task<Result> Login(string username, string password, CancellationToken cToken)
        //{

        //    if (await _OPratorServices.Login(username, password, cToken) == null)
        //    {
        //        return new Result(false, "نام کاربری یا رمز عبور اشتباه است.");


        //    }
        //    else
        //    {
        //        await _OPratorServices.Login(username, password, cToken);
        //        return new Result(true, "خوش آمدید.");

        //    }
        //}

      

        public async Task<List<Role>> GetRoles(CancellationToken cToken)
        {
            return await _OPratorServices.GetRoles(cToken);
        }
    }
}
