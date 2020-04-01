using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CSGS.Models.Entities
{
    public class CursoExt
    {

        [Key]
        public int IdCursoExt { get; set; }



        public int IdCategoriaExt { get; set; }





        [MaxLength(120)]
        public string TituloCursoExt { get; set; }


        [MaxLength(255)]
        public string DescripcionCursoExt { get; set; }

        [MaxLength(255)]
        public string ObjetivosCurso { get; set; }

        [MaxLength(254)]
        public string ReqCurso { get; set; }

        [MaxLength(450)]
        public string TemarioCurso { get; set; }

        [MaxLength(100)]
        public string NivelCurso { get; set; }


        public DateTime? FechaInicioClases { get; set; }
        public DateTime? FechaInicioMat { get; set; }
        public DateTime? FechaFinMat { get; set; }

        public int AudienciaCurso { get; set; }
        public int DuracionCurso { get; set; }




        public string IdAdmin { get; set; }


        public virtual ICollection<MatriculaDoc> MatriculaDoc { get; set; }

        public virtual CategoriaExt CategoriaExt { get; set; }

    }
}
