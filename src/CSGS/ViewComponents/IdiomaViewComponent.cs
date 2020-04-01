using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSGS.ViewComponents
{
    public class IdiomaViewComponent : ViewComponent

    {

        public async Task<IViewComponentResult>
               InvokeAsync()
        {

            var idiomas = new List<SelectListItem>();
            idiomas.Add(new SelectListItem()
            {
                Value = "en-US",
                Text = "English"
            }
             );
            idiomas.Add(new SelectListItem()
            {
                Value = "es-PE",
                Text = "Spanish"
            }
             );

            idiomas.Add(new SelectListItem()
            {
                Value = "fr-FR",
                Text = "French"
            }
             );


            var currentCulture = HttpContext.Features.Get
                        <IRequestCultureFeature>();

            ViewBag.IdiomaSel = currentCulture.RequestCulture.UICulture.Name;


            return View(idiomas);

        }

    }
}
