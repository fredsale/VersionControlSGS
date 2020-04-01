using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CSGS.Models.Entities
{
    public class MatriculaDoc
    {


        [Key]
        public int IdMatriculaDoc { get; set; }

        [MaxLength(450)]
        public string IdEstudiante { get; set; }


        public int IdCursoExt { get; set; }


        public DateTime? Fechamatricula { get; set; }

        

        public virtual CursoExt CursoExt { get; set; }




    }
}
