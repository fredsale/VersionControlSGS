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
    [Authorize]
    public class SolicitudController : Controller
    {

        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;


        public SolicitudController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {


            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult Index()
        {
            ViewBag.IdSolicitante =userManager.GetUserId(User);
            //ViewBag.IdSolicitante = "asdf";
            var da = new SolicitudDA();
            var model = da.GetSolicitudes();
            return View(model);
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexP()
        {
            ViewBag.IdSolicitante = userManager.GetUserId(User);
            
            //ViewBag.IdSolicitante = "asdf";
            var da = new SolicitudDA();
            var model = da.GetSolicitudAvanzado(1).ToList();
            return View(model);



            //buscar.Categorias = categoriaDA.GetCategorias().ToList();

            //buscar.Productos = productDA.GetProductosAvanzado(buscar.FiltroByNombre,
            //    buscar.FiltroByCategoria, buscar.FiltroByStockFrom,
            //    buscar.FiltroByStockTo).ToList();

            //return View("Buscar", buscar);

        }


        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexAP()
        {
            ViewBag.IdSolicitante = userManager.GetUserId(User);
            //ViewBag.IdSolicitante = "asdf";
            var da = new SolicitudDA();
            var model = da.GetSolicitudAvanzado(2).ToList();
            return View(model);



            //buscar.Categorias = categoriaDA.GetCategorias().ToList();

            //buscar.Productos = productDA.GetProductosAvanzado(buscar.FiltroByNombre,
            //    buscar.FiltroByCategoria, buscar.FiltroByStockFrom,
            //    buscar.FiltroByStockTo).ToList();

            //return View("Buscar", buscar);

        }



        [Authorize(Policy = "AllowCreate")]
        public IActionResult Detalles(int id)
        {
            //var solDA = new SolicitudDA();
            var solDA = new SolicitudDA();
            //ViewBag.Categorias = categoriaDA.GetCategorias();
            var motDA = new MotivoDA();
            ViewBag.Motivos = motDA.GetMotivos();

            var model = solDA.GetSolicitud(id);

            return View(model);

        }


        [Authorize(Policy = "AllowCreate")]
        public IActionResult Create()
        {
            var solDA = new SolicitudDA();
            ViewBag.Solicitud = solDA.GetSolicitudes();

            var motDA = new MotivoDA();
            ViewBag.Motivos = motDA.GetMotivos();



            ViewBag.IdSolicitanteid = userManager.GetUserId(User);

            var user = userManager.FindByIdAsync(ViewBag.IdSolicitanteid).Result;
            ViewBag.IdSolicitante = user.FirstName;
           //// ViewBag.IdSolicitanteApe = user.LastName;


            return View();

        }


        [Authorize(Policy = "AllowCreate")]
        [HttpPost]


        public IActionResult Create(Solicitud Solicitud)
        {
            //egresado.idAlum = "22";
            //Solicitud.fechaActu = DateTime.Now;
            Solicitud.IdSolicitante = userManager.GetUserId(User);
            Solicitud.IdEstado = 1;
            

            var prodDA = new SolicitudDA();
            var result = prodDA.InsertSolicitud(Solicitud);

            if (result != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Solicitud);
            }

        }






        public IActionResult Edit(int id)
        {
            //var solDA = new SolicitudDA();
            var solDA = new SolicitudDA();
            //ViewBag.Categorias = categoriaDA.GetCategorias();
            var motDA = new MotivoDA();
            ViewBag.Motivos = motDA.GetMotivos();

            var model = solDA.GetSolicitud(id);

            return View(model);
        }


      

        [HttpPost]
        public IActionResult Edit(Solicitud Solicitud)
        {
           

            var solDA = new SolicitudDA();

            Solicitud.IdSupervisor = userManager.GetUserId(User);
            //Solicitud.DescripcionViaje = "FUNCIONA ESTADOchichi";
            //Solicitud.IdEstado = 3;
            string estaapro = Convert.ToString(HttpContext.Request.Form["estado2"].ToString());
            string estarecha = Convert.ToString(HttpContext.Request.Form["estado3"].ToString());
            int idest;

            if (!String.IsNullOrWhiteSpace(estaapro))
            {
                idest = 2;
                Solicitud.IdEstado = idest;
            }
            else if (!String.IsNullOrWhiteSpace(estarecha))
            {
                idest = 3;
                Solicitud.IdEstado = idest;
            }
            //else if (value <= 100)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 2;
            //}
            
            var result = solDA.UpdateProduct(Solicitud);

            if (result)
            {
                return RedirectToAction("IndexP");
            }
            else
            {
                return View(Solicitud);
            }


        }




        //public IActionResult Edit(string id)
        //{
        //    //var catDA = new CategoriaDA();
        //    //ViewBag.Categorias = catDA.GetCategorias();

        //    var prodDA = new SolicitudDA();
        //    var model = prodDA.GetEgresado(id);

        //    return View(model);
        //}

        //[HttpPost]

        //public IActionResult Edit(Solicitud Solicitud)
        //{
        //    // product.ProductID = 0;
        //    Solicitud.fechaActu = DateTime.Now;
        //    var prodDA = new SolicitudDA();
        //    var result = prodDA.UpdateEgresado(Solicitud);

        //    if (result)
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    else

        //    {
        //        return View(Solicitud);
        //    }
        //}






        //public IActionResult Delete(string id)
        //{
        //    var prodDA = new SolicitudDA();
        //    var model = prodDA.GetEgresado(id);

        //    return View(model);
        //}

        //[HttpPost]


        //public IActionResult Delete(Solicitud Solicitud)
        //{
        //    // product.ProductID = 0;
        //    Solicitud.fechaActu = DateTime.Now;
        //    var prodDA = new SolicitudDA();
        //    var result = prodDA.DeleteEgresado(Solicitud);

        //    if (result)
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    else

        //    {
        //        return View(Solicitud);
        //    }
        //}


    }

}