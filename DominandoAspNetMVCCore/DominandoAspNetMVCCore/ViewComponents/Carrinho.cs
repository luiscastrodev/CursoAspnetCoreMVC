using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominandoAspNetMVCCore.ViewComponents
{
    [ViewComponent(Name = "Carrinho")]
    public class Carrinho : ViewComponent
    {
        public int Quantidade { get; set; }

        public Carrinho()
        {
            this.Quantidade = 5;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(this.Quantidade);
        }
    }
}
