using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSGS.Data.DataAccess;
using CSGS.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CSGS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Security.Application;

namespace CSGS.Controllers
{

    //Uso de la libreria de Aspnetcore Authorization
    [Authorize]
    public class CursoExtController : Controller
    {

        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;




        
        public CursoExtController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {


            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult Index()
        {
            ViewBag.IdAdmin = userManager.GetUserId(User);
      
            var da = new CursoExtDA();
            var model = da.GetSolicitudes();
            return View(model);
        }


        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexSG()
        {
            ViewBag.IdAdmin = userManager.GetUserId(User);
           
            var da = new CursoExtDA();
            var model = da.GetSolicitudes();
            return View(model);
        }





        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexP()
        {
            ViewBag.IdCursoExt = userManager.GetUserId(User);

            var da = new CursoExtDA();
            var model = da.GetSolicitudAvanzado(1).ToList();
            return View(model);
                        

        }


        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexAP()
        {
            ViewBag.IdCursoExt = userManager.GetUserId(User);
          
            var da = new CursoExtDA();
            var model = da.GetSolicitudAvanzado(2).ToList();
            return View(model);





        }



        [Authorize(Policy = "AllowCreate")]
        public IActionResult Detalles(int id)
        {
      
            var solDA = new CursoExtDA();
         
            var motDA = new CategoriaExtDA();
            ViewBag.CategoriaExt = motDA.GetMotivos();

            var model = solDA.GetSolicitud(id);

            return View(model);

        }


        [Authorize(Policy = "AllowCreate")]
        public IActionResult Create()
        {
            var solDA = new CursoExtDA();
            ViewBag.CursoExt = solDA.GetSolicitudes();

            var motDA = new CategoriaExtDA();
            ViewBag.CategoriaExt = motDA.GetMotivos();



            ViewBag.IdCursoExtid = userManager.GetUserId(User);

            var user = userManager.FindByIdAsync(ViewBag.IdCursoExtid).Result;
            ViewBag.IdCursoExt = user.FirstName;
            //Extrae el apellido del usuario// ViewBag.IdSolicitanteApe = user.LastName;


            return View();

        }


        [Authorize(Policy = "AllowCreate")]
        [HttpPost]


        public IActionResult Create(CursoExt CursoExt)
        {
    


            var prodDA = new CursoExtDA();
            var result = prodDA.InsertSolicitud(CursoExt);

            if (result != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(CursoExt);
            }

        }




        [Authorize(Policy = "AllowCreate")]

        public IActionResult Edit(int id)
        {
           
            var solDA = new CursoExtDA();
    
            var motDA = new CategoriaExtDA();
            ViewBag.CategoriaExt = motDA.GetMotivos();

            var model = solDA.GetSolicitud(id);

            return View(model);
        }



        [Authorize(Policy = "AllowCreate")]
        [HttpPost]
        public IActionResult Edit(CursoExt CursoExt)
        {


            var solDA = new CursoExtDA();

            CursoExt.IdAdmin = userManager.GetUserId(User);
           
            string estaapro = Convert.ToString(HttpContext.Request.Form["estado2"].ToString());
            string estarecha = Convert.ToString(HttpContext.Request.Form["estado3"].ToString());
            int idest;

            if (!String.IsNullOrWhiteSpace(estaapro))
            {
                //idest = 2;
            
            }
            else if (!String.IsNullOrWhiteSpace(estarecha))
            {
                //idest = 3;
          
            }
         
            var result = solDA.UpdateProduct(CursoExt);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(CursoExt);
            }


        }






        public IActionResult EditSG(int id)
        {
         
            var solDA = new CursoExtDA();
           
            var motDA = new CategoriaExtDA();
            ViewBag.CategoriaExt = motDA.GetMotivos();

            var model = solDA.GetSolicitud(id);

            return View(model);
        }




        [HttpPost]
        public IActionResult EditSG(CursoExt CursoExt)
        {


            var solDA = new CursoExtDA();

            CursoExt.IdAdmin = userManager.GetUserId(User);
         
            string estaapro = Convert.ToString(HttpContext.Request.Form["estado2"].ToString());
            string estarecha = Convert.ToString(HttpContext.Request.Form["estado3"].ToString());
            int idest;

            if (!String.IsNullOrWhiteSpace(estaapro))
            {
                //idest = 2;
           
            }
            else if (!String.IsNullOrWhiteSpace(estarecha))
            {
                //idest = 3;
          
            }
      

            var result = solDA.UpdateProduct(CursoExt);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(CursoExt);
            }


        }


        //Codigo para eliminar cursos
        //public IActionResult Delete(string id)
        //{
        //    var prodDA = new CursoExtDA();
        //    var model = prodDA.GetCursoExt(id);

        //    return View(model);
        //}


        //[HttpPost]

                //public IActionResult Delete(CursoExt CursoExt)
        //{
        //   
        //    CursoExt.fechaActu = DateTime.Now;
        //    var prodDA = new CursoExtDA();
        //    var result = prodDA.DeleteCursoExt(CursoExt);

        //    if (result)
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    else

        //    {
        //        return View(CursoExt);
        //    }
        //}



    }






}