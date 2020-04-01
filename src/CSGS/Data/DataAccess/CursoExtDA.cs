using CSGS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CSGS.Data.DataAccess
{
    public class CursoExtDA
    {

        public IEnumerable<CursoExt> GetSolicitudes(string nombre = "")
        {
            var listado = new List<CursoExt>();

            using (var db = new ApplicationDbContext())
            {
          
                var query = db.CursoExt.Include(item => item.CategoriaExt);
                query.OrderBy(item => item.CategoriaExt.NombreCategoriaExt);
                                    
                listado = query.ToList();
            }

            return listado;

        }


        public IEnumerable<CursoExt> GetCursos()
        {
            var listado = new List<CursoExt>();
            using (var db = new ApplicationDbContext())
            {
                var query = db.CursoExt.ToList();
                listado = query.ToList();
            }
            return listado;
        }




        public IEnumerable<CursoExt> GetSolicitudAvanzado(
                int filtroByIdEstado
            )


        {
            var listado = new List<CursoExt>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<CursoExt> query = db.CursoExt.Include(item => item.CategoriaExt);

                query.OrderBy(item => item.IdCategoriaExt);
                listado = query.ToList();
            }

            return listado;

        }



        


        public CursoExt GetSolicitud(int idSoli)
        {
            var result = new CursoExt();
            using (var db = new ApplicationDbContext())
            {
                result = db.CursoExt.Where(item => item.IdCursoExt == idSoli).FirstOrDefault();
            }

            return result;
        }

        public int InsertSolicitud(CursoExt entity)
        {
          
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges(); //Guardando en base de datos
                result = entity.IdCursoExt;
            }

            return result;
        }


        public bool UpdateProduct(CursoExt entity)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.CursoExt.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                result = db.SaveChanges() != 0; //Guardando en base de datos
            }

            return result;
        }


    }
}
