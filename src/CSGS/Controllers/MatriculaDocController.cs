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
    public class MatriculaDocController : Controller
    {

        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;




        public MatriculaDocController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {


            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult Index()
        {
            ViewBag.IdEstudiante = userManager.GetUserId(User);
            //ViewBag.IdSolicitante = "asdf";
         
            var da = new MatriculaDocDA();
            var model = da.GetSolicitudes();
            return View(model);
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexA()
        {
            ViewBag.IdEstudiante = userManager.GetUserId(User);
            //ViewBag.IdSolicitante = "asdf";

            var da = new MatriculaDocDA();
            var model = da.GetSolicitudes();
            return View(model);



            //buscar.Categorias = categoriaDA.GetCategorias().ToList();

            //buscar.Productos = productDA.GetProductosAvanzado(buscar.FiltroByNombre,
            //    buscar.FiltroByCategoria, buscar.FiltroByStockFrom,
            //    buscar.FiltroByStockTo).ToList();

            //return View("Buscar", buscar);

        }


        //NO USADO
        //[Authorize(Policy = "AllowSearch")]
        //public IActionResult IndexP()
        //{
        //    ViewBag.IdEstudiante = userManager.GetUserId(User);

        //    //ViewBag.IdSolicitante = "asdf";
        //    var da = new MatriculaDocDA();
        //    var model = da.GetSolicitudAvanzado(1).ToList();
        //    return View(model);



        //    //buscar.Categorias = categoriaDA.GetCategorias().ToList();

        //    //buscar.Productos = productDA.GetProductosAvanzado(buscar.FiltroByNombre,
        //    //    buscar.FiltroByCategoria, buscar.FiltroByStockFrom,
        //    //    buscar.FiltroByStockTo).ToList();

        //    //return View("Buscar", buscar);

        //}


        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexAP()
        {
            ViewBag.IdEstudiante = userManager.GetUserId(User);
  
            //ViewBag.IdSolicitante = "asdf";
            var da = new MatriculaDocDA();
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
            var solDA = new MatriculaDocDA();
            //ViewBag.Categorias = categoriaDA.GetCategorias();
            var motDA = new CursoExtDA();
            ViewBag.prueba = "si funciona";
            ViewBag.CursoExt = motDA.GetCursos();

            var model = solDA.GetSolicitud(id);

            return View(model);
     
        }


        //[Authorize(Policy = "AllowCreate")]
        [Authorize(Policy = "AllowStudents")]
        public IActionResult Create()
        {
            var solDA = new MatriculaDocDA();
            ViewBag.MatriculaDoc = solDA.GetSolicitudes();

            var motDA = new CursoExtDA();
            ViewBag.CursoExt = motDA.GetCursos();


            ViewBag.IdEstudianteid = userManager.GetUserId(User);

            var user = userManager.FindByIdAsync(ViewBag.IdEstudianteid).Result;
            ViewBag.IdEstudiante = user.FirstName;
            //// ViewBag.IdSolicitanteApe = user.LastName;


            return View();

        }


        //[Authorize(Policy = "AllowCreate")]
        [Authorize(Policy = "AllowStudents")]
        [HttpPost]


        public IActionResult Create(MatriculaDoc MatriculaDoc)
        {
            //egresado.idAlum = "22";
            //Solicitud.fechaActu = DateTime.Now;
            MatriculaDoc.IdEstudiante = userManager.GetUserId(User);
            //MatriculaDoc.IdEstado = 1;
            MatriculaDoc.Fechamatricula = DateTime.Now;
         
            var prodDA = new MatriculaDocDA();
            var result = prodDA.InsertSolicitud(MatriculaDoc);

            if (result != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(MatriculaDoc);
            }

        }






        public IActionResult Edit(int id)
        {
            //var solDA = new SolicitudDA();
            var solDA = new MatriculaDocDA();
            //ViewBag.Categorias = categoriaDA.GetCategorias();
            var motDA = new CursoExtDA();
            ViewBag.CursoExt = motDA.GetCursos();
        
            var model = solDA.GetSolicitud(id);

            return View(model);
        }




        [HttpPost]
        public IActionResult Edit(MatriculaDoc MatriculaDoc)
        {


            var solDA = new MatriculaDocDA();
     
            MatriculaDoc.Fechamatricula = DateTime.Now;
            //MatriculaDoc.IdSupervisor = userManager.GetUserId(User);
            //Solicitud.DescripcionViaje = "FUNCIONA ESTADOchichi";
            //Solicitud.IdEstado = 3;
            string estaapro = Convert.ToString(HttpContext.Request.Form["estado2"].ToString());
            string estarecha = Convert.ToString(HttpContext.Request.Form["estado3"].ToString());
            int idest;

            if (!String.IsNullOrWhiteSpace(estaapro))
            {
                //idest = 2;
                //Solicitud.IdEstado = idest;
            }
            else if (!String.IsNullOrWhiteSpace(estarecha))
            {
                //idest = 3;
                //Solicitud.IdEstado = idest;
            }
            //else if (value <= 100)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 2;
            //}

            var result = solDA.UpdateProduct(MatriculaDoc);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(MatriculaDoc);
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









        //public IActionResult Index()
        //{
        //    return View();
        //}
    }







}