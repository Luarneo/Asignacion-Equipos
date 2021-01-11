using FrontAsignacionActivoFijo.Consumidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontAsignacionActivoFijo.Controllers
{
    public class HomeController : Controller
    {

        private IConsuidorUbicaciones servicio;

        public HomeController() : this(new ConsumidorUbicaciones()) { }

        public HomeController(IConsuidorUbicaciones servicio)
        {
            this.servicio = servicio;
        }

        //public async Task<ActionResult> Index()
        //{

        //    ViewBag.listaok = await servicio.ObtenerUbicaciones();
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}