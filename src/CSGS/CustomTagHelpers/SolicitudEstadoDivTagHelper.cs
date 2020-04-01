using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CSGS.CustomTagHelpers
{

    public class SolicitudEstadoDivTagHelper : TagHelper
    {


        public int Estado { get; set; }


        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {


            string img = "";
            if (this.Estado == 1)
            {
                img = "circulo-azul.png";
            }
            else if(this.Estado == 2)
            {
                img = "circulo-verde.png";
            }
            else if(this.Estado == 3)
            {
                img = "circulo-rojo.png";
            }

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "panel");
            img = $"/images/{img}";//ruta relativa de la imagen...

            StringBuilder htmlString = new StringBuilder();
            htmlString.Append($"<img src='{img}' />");
            htmlString.Append($"<span class='label label-default'>{this.Estado}</span>");

            output.Content.AppendHtml(htmlString.ToString());



            return base.ProcessAsync(context, output);

        }


    }




}
