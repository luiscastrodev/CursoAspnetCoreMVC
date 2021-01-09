using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DominandoAspNetMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DominandoAspNetMVCCore.Controllers
{
    public class FilmeController : Controller
    {
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            if (ModelState.IsValid)
            {

            }

            return View(filme);
        }
    }
}
