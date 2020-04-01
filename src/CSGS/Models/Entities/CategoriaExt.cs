using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSGS.Models.Entities
{
    public class CategoriaExt
    {



        [Key]
        public int IdCategoriaExt { get; set; }


        public string NombreCategoriaExt { get; set; }

        public virtual ICollection<CursoExt> CursoExt { get; set; }















    }
}
