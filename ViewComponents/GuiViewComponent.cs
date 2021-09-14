using fiapweb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.ViewComponents
{
    public class GuiViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes)
        {
            var view = noticiasUrgentes ? "noticiasurgentes" : "noticias";

            var items = GetItems(total);

            return View(view, items);
        }

        private IEnumerable<Noticia> GetItems(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i + 1, Titulo = $"Noticia sobre {i}", Link = $"https://noticias?id={i + 1}" };
            }
        }
    }
}
