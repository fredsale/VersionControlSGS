using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace CSGS.CustomTagHelpers
{
    public class SolicitudEstadoTagHelper : TagHelper
    {

        public int Estado { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //string img = "";
            //if (this.Estado == 2)
            //{
            //    img = "circulo-verde.png";
            //}
            //else
            //{
            //    img = "circulo-rojo.png";
            //}


            string img = "";
            if (this.Estado == 1)
            {
                img = "circulo-azul.png";
            }
            else if (this.Estado == 2)
            {
                img = "circulo-verde.png";
            }
            else if (this.Estado == 3)
            {
                img = "circulo-rojo.png";
            }

            output.TagName = "img";
            img = $"/images/{img}";//ruta relativa de la imagen...
            output.Attributes.SetAttribute("src", img);


            return base.ProcessAsync(context, output);

        }

    }
}
