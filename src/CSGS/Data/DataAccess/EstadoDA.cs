using CSGS.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGS.Data.DataAccess
{
    public class EstadoDA
    {


        public IEnumerable<Estado> GetEstados()
        {
            var listado = new List<Estado>();
            using (var db = new ApplicationDbContext())
            {
                var query = db.Estado.ToList();
                listado = query.ToList();
            }
            return listado;
        }

        public Estado GetEstado(int id)
        {
            var result = new Estado();
            using (var db = new ApplicationDbContext())
            {
                result = db.Estado.Where(item => item.IdEstado == id).FirstOrDefault();

            }
            return result;
        }

        public int InsertEstado(Estado entity)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges();
                result = entity.IdEstado;
            }
            return result;
        }

    }
}
