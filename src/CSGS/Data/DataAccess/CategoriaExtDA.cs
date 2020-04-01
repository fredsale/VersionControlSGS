using CSGS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGS.Data.DataAccess
{
    public class CategoriaExtDA
    {

        public IEnumerable<CategoriaExt> GetMotivos()
        {
            var listado = new List<CategoriaExt>();
            using (var db = new ApplicationDbContext())
            {
                var query = db.CategoriaExt.ToList();
                listado = query.ToList();
            }
            return listado;
        }

        public CategoriaExt GetMotivo(int id)
        {
            var result = new CategoriaExt();
            using (var db = new ApplicationDbContext())
            {
                result = db.CategoriaExt.Where(item => item.IdCategoriaExt == id).FirstOrDefault();

            }
            return result;
        }

        public int InsertMotivo(CategoriaExt entity)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(entity);
                db.SaveChanges();
                result = entity.IdCategoriaExt;
            }
            return result;
        }

    }
}
