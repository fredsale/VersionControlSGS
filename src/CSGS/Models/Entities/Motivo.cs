using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CSGS.Models.Entities
{
    public class Motivo
    {
        [Key]
        public int IdMotivo { get; set; }


        public string NombreMotivo { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
