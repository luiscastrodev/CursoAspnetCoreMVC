using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            _pedidoRepository.ObterPedido();

            return View();
        }


        //outro tipo de injecao dependencia
        public IActionResult Index2([FromServices] IPedidoRepository pedidoRepository)
        {
            _pedidoRepository.ObterPedido();

            return View("Index");
        }
    }
}
