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
         
            var da = new MatriculaDocDA();
            var model = da.GetSolicitudes();
            return View(model);
        }



        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexA()
        {
            ViewBag.IdEstudiante = userManager.GetUserId(User);
         
            var da = new MatriculaDocDA();
            var model = da.GetSolicitudes();
            return View(model);

            

        }


     


        [Authorize(Policy = "AllowSearch")]
        public IActionResult IndexAP()
        {
            ViewBag.IdEstudiante = userManager.GetUserId(User);
  
           
            var da = new MatriculaDocDA();
            var model = da.GetSolicitudAvanzado(2).ToList();
            return View(model);


        }



        [Authorize(Policy = "AllowCreate")]
        public IActionResult Detalles(int id)
        {
 
            var solDA = new MatriculaDocDA();
        
            var motDA = new CursoExtDA();
            ViewBag.prueba = "si funciona";
            ViewBag.CursoExt = motDA.GetCursos();

            var model = solDA.GetSolicitud(id);

            return View(model);
     
        }


       //Se comento esta linea para autorizar solo accion create en la vista MatriculaDoc para los estudiantes, quitando el acceso al usuario Admin 
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
    

            return View();

        }


        //Se comento esta linea para autorizar solo accion create en la vista MatriculaDoc para los estudiantes, quitando el acceso al usuario Admin 
        //[Authorize(Policy = "AllowCreate")]
        [Authorize(Policy = "AllowStudents")]
        [HttpPost]


        public IActionResult Create(MatriculaDoc MatriculaDoc)
        {
   
            MatriculaDoc.IdEstudiante = userManager.GetUserId(User);
        
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
        
            var solDA = new MatriculaDocDA();
   
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






    }

}