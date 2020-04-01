using CSGS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGS.Data.DataAccess
{
    public class MotivoDA
    {


        public IEnumerable<Motivo> GetMotivos()
        {
            var listado = new List<Motivo>();
            using (var db = new ApplicationDbContext())
            {
                var query = db.Motivo.ToList();
                listado = query.ToList();
            }
            return listado;
        }

        public Motivo GetMotivo(int id)
        {
            var result = new Motivo();
            using (var db = new ApplicationDbContext())
            {
                result = db.Motivo.Where(item => item.IdMotivo == id).FirstOrDefault();

            }
            return result;
        }

        public int InsertMotivo(Motivo entity)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges();
                result = entity.IdMotivo;
            }
            return result;
        }


    }
}
