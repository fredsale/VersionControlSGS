using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CSGS.Models;
using CSGS.Areas.Security.Models.UserViewModels;

namespace CSGS.Areas.Security.Controllers
{
    public class UserManagerController : Controller
    {
        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;

        public UserManagerController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {

            var model = this.userManager.Users.ToList();
            return View(model);
        }


        public IActionResult Create()
        {

            var model = new RegisterViewModel();
            model.Roles = roleManager.Roles.ToList();
            return View(model);

        }


        [HttpPost]

        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            var user = new ApplicationUser();
            user.UserName = model.Email;
            //user.FirstName = model.FirstName;
            ///user.LastName = model.LastName;
            //user.DNI = model.DNI;
            user.Email = model.Email;
            //user.Address = model.Address;

            //Guardando informacion del usuario
            var userSaved = await userManager.CreateAsync(user, "P@$$w0rd");
            if (userSaved.Succeeded)
            {

                await userManager.AddToRoleAsync(user, model.RoleId);
            }

            return RedirectToAction("Index");
        }



        public IActionResult Edit(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var model = new RegisterViewModel();

            model.UserId = user.Id;
            model.UserName = user.UserName;
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            //model.DNI = user.DNI;
            model.Email = user.Email;
            //model.Address = user.Address;
            ///model.RoleId = "";
            var roles = userManager.GetRolesAsync(user).Result;

            if (roles != null && roles.Count > 0)
            {

                model.RoleId = roles.FirstOrDefault();
            }
            model.Roles = roleManager.Roles.ToList();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterViewModel model)
        {

            var user = userManager.FindByIdAsync(model.UserId).Result;

            user.UserName = model.Email;
            //user.FirstName = model.FirstName;
            //user.LastName = model.LastName;
            //user.DNI = model.DNI;
            user.Email = model.Email;
            //user.Address = model.Address;


            //guardando informacion del usuario
            var userSaved = await userManager.UpdateAsync(user);

            if (userSaved.Succeeded)
            {
                //var rolesCollection =roleManager.Roles.Select(item=>item.NormalizedName).ToList();
                var rolesCollection = userManager.GetRolesAsync(user).Result;
                var rolesRemoved = await userManager.RemoveFromRolesAsync(user, rolesCollection);

                if (rolesRemoved.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, model.RoleId);
                }
            }

            return RedirectToAction("Index");
        }










    }
}