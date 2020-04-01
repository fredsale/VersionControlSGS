using CSGS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CSGS.Data.DataAccess
{
    public class MatriculaDocDA
    {


        public IEnumerable<MatriculaDoc> GetSolicitudes(string nombre = "")
        {
            var listado = new List<MatriculaDoc>();

            using (var db = new ApplicationDbContext())
            {
              

                var query = db.MatriculaDoc.Include(item => item.CursoExt);
                query.OrderBy(item => item.CursoExt.TituloCursoExt);
                //Ordenando por dos o mas columnas (usar el método ThenBy ) en forma ascedente
                //query.OrderBy(item => item.CursoExt.TituloCursoExt).ThenBy(item => item.CreationDate);
                //Ordenando en forma descendente
                //query.OrderByDescending(item => item.CursoExt.TituloCursoExt);

                listado = query.ToList();
            }

            return listado;

        }

        

        

        public IEnumerable<MatriculaDoc> GetSolicitudAvanzado(
                int filtroByIdEstado
            )


        {
            var listado = new List<MatriculaDoc>();

            using (var db = new ApplicationDbContext())
            {
                IQueryable<MatriculaDoc> query = db.MatriculaDoc.Include(item => item.CursoExt);



                if (filtroByIdEstado == 1)
                {
                  //
                }
                else if (filtroByIdEstado == 2)
                {
                 // ----  //
                }

                query.OrderBy(item => item.CursoExt);
                listado = query.ToList();
            }

            return listado;

        }









        public MatriculaDoc GetSolicitud(int idSoli)
        {
            var result = new MatriculaDoc();
            using (var db = new ApplicationDbContext())
            {
                result = db.MatriculaDoc.Where(item => item.IdMatriculaDoc == idSoli).FirstOrDefault();
            }

            return result;
        }

        public int InsertSolicitud(MatriculaDoc entity)
        {
      
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges(); //Guardando en base de datos
                result = entity.IdMatriculaDoc;
            }

            return result;
        }


        public bool UpdateProduct(MatriculaDoc entity)
        {
            var result = false;
            using (var db = new ApplicationDbContext())
            {
                db.MatriculaDoc.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                result = db.SaveChanges() != 0; //Guardando en base de datos
            }

            return result;
        }

     



    }
}
