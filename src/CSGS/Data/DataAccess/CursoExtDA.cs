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
                //IQueryable<Solicitud> query = db.Solicitud.Include(item => item.Estado);

                var query = db.CursoExt.Include(item => item.CategoriaExt);
                query.OrderBy(item => item.CategoriaExt.NombreCategoriaExt);


                //if (!String.IsNullOrWhiteSpace(nombre))
                //{
                //    query = query.Where(item => item.nombre.Contains(nombre));
                //}

           //no     //query.OrderBy(item => item.FechaViaje);
                //Ordenando por dos o mas columnas (usar el método ThenBy ) en forma ascedente
                //query.OrderBy(item => item.Nombre).ThenBy(item => item.CreationDate);
                //Ordenando en forma descendente
                //query.OrderByDescending(item => item.Nombre);

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


                //var query = db.Solicitud.Include(item => item.Motivo);
                //query.OrderBy(item => item.Estado.NombreEstado);


                //if (!String.IsNullOrWhiteSpace(filtroByNombre))
                //{
                //    query = query.Where(item => item.Nombre.Contains(filtroByNombre));
                //}

                ////////if (filtroByIdEstado == 1)
                ////////{
                ////////    query = query.Where(item => item.IdEstado == filtroByIdEstado);
                ////////}
                ////////else if (filtroByIdEstado == 2)
                ////////{
                ////////    query = query.Where(item => item.IdEstado == filtroByIdEstado);
                ////////}

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
            //var result = 0;
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
                //db.Entry(entity).Property(item => item.IdEstado).IsModified = false;
                result = db.SaveChanges() != 0; //Guardando en base de datos
            }

            return result;
        }


    }
}
