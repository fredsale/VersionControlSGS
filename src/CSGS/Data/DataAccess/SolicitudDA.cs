using CSGS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CSGS.Data.DataAccess
{
    public class SolicitudDA
    {

        public IEnumerable<Solicitud> GetSolicitudes(string nombre = "")
        {
            var listado = new List<Solicitud>();

            using (var db = new ApplicationDbContext())
            {
                //IQueryable<Solicitud> query = db.Solicitud.Include(item => item.Estado);

                var query = db.Solicitud.Include(item => item.Motivo);
                query.OrderBy(item => item.Estado.NombreEstado);


                //if (!String.IsNullOrWhiteSpace(nombre))
                //{
                //    query = query.Where(item => item.nombre.Contains(nombre));
                //}

                query.OrderBy(item => item.FechaViaje);
                //Ordenando por dos o mas columnas (usar el método ThenBy ) en forma ascedente
                //query.OrderBy(item => item.Nombre).ThenBy(item => item.CreationDate);
                //Ordenando en forma descendente
                //query.OrderByDescending(item => item.Nombre);

                listado = query.ToList();
            }

            return listado;

        }







        public IEnumerable<Solicitud> GetSolicitudAvanzado(
                int filtroByIdEstado
            )


        {
            var listado = new List<Solicitud>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<Solicitud> query = db.Solicitud.Include(item => item.Estado).Include(item=> item.Motivo);


                //var query = db.Solicitud.Include(item => item.Motivo);
                //query.OrderBy(item => item.Estado.NombreEstado);


                //if (!String.IsNullOrWhiteSpace(filtroByNombre))
                //{
                //    query = query.Where(item => item.Nombre.Contains(filtroByNombre));
                //}

                if (filtroByIdEstado == 1)
                {
                    query = query.Where(item => item.IdEstado == filtroByIdEstado);
                }
                else if (filtroByIdEstado == 2)
                {
                    query = query.Where(item => item.IdEstado == filtroByIdEstado);
                }

                query.OrderBy(item => item.IdEstado);
                listado = query.ToList();
            }

            return listado;

        }









        public Solicitud GetSolicitud(int idSoli)
        {
            var result = new Solicitud();
            using (var db = new ApplicationDbContext())
            {
                result = db.Solicitud.Where(item => item.IdSolicitud == idSoli).FirstOrDefault();
            }

            return result;
        }

        public int InsertSolicitud(Solicitud entity)
        {
            //var result = 0;
            var result=0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges(); //Guardando en base de datos
                result = entity.IdSolicitud;
            }

            return result;
        }


        public bool UpdateProduct(Solicitud entity)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.Solicitud.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.Entry(entity).Property(item => item.IdEstado).IsModified = false;
                result = db.SaveChanges() != 0; //Guardando en base de datos
            }

            return result;
        }

        //public bool UpdateProduct(Producto entity)
        //{
        //    var result = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Producto.Attach(entity);
        //        db.Entry(entity).State = EntityState.Modified;
        //        db.Entry(entity).Property(item => item.CreationDate).IsModified = false;
        //        result = db.SaveChanges() != 0; //Guardando en base de datos
        //    }

        //    return result;
        //}

        //public bool UpdateStock(int id, decimal stock)
        //{
        //    var result = false;

        //    using (var db = new ApplicationDbContext())
        //    {
        //        var prod = db.Producto.Where(item => item.ProductID == id).FirstOrDefault();

        //        prod.Stock = prod.Stock + stock;
        //        db.Entry(prod).Property(item => item.Stock).IsModified = true;
        //        result = db.SaveChanges() != 0;
        //    }
        //    return result;

        //}

        //public bool DeleteProduct(int id)

        //{
        //    var result = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        var entity = new Producto() { ProductID = id };
        //        db.Producto.Attach(entity);
        //        db.Producto.Remove(entity);
        //        result = db.SaveChanges() != 0;  //Guardando en base de datos.

        //    }
        //    return result;
        //}











    }
}
