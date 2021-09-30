using fiapweb.core.Models;
using fiapweb.core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        private INoticiaService _service;

        public NoticiasViewComponent(INoticiaService service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var view = noticiasUrgentes ? "noticiasurgentes" : "noticias";


            return View(view, _service.Load(total));
        }

    }
}
