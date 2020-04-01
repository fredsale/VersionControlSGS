using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSGS.Models.Entities
{
    public class Solicitud
    {

        [Key]
        public int IdSolicitud { get; set; }

        [MaxLength(450)]
        public string IdSolicitante { get; set; }


        public int IdMotivo { get; set; }
        public int IdEstado { get; set; }

        public DateTime? FechaViaje { get; set; }
        public string DescripcionViaje { get; set; }
        public int DuracionViaje { get; set; }
        public decimal MontoGastar { get; set; }
        public decimal GastosMovilidad { get; set; }
        public decimal GastosHotel { get; set; }

        public string IdSupervisor { get; set; }
        public string SustentoSupervisor { get; set; }
        


        public virtual Estado Estado { get; set; }
        public virtual Motivo Motivo { get; set; }
        //public virtual Supervisor Supervisor { get; set; }

    }
}
