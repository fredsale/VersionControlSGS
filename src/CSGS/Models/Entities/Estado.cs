using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSGS.Models.Entities
{
    public class Estado
    {

        [Key]
        public int IdEstado { get; set; }

             
        public string NombreEstado { get; set; }


        public virtual ICollection<Solicitud> Solicitud { get; set; }

    }
}
