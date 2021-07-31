using FrontAsignacionActivoFijo.Consumidor;
using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HtmlHelpers.BeginCollectionItem;

namespace FrontAsignacionActivoFijo.Controllers
{
    public class ComponentesController : Controller
    {


        private IConsumidorActivo _ServicioActivo;
        private IConsumidorCatalogos _ServicioCatalogos;
        private IConsuidorUbicaciones _ServicioUbicaciones;
        private IConsumidorComponentes _ServicioComponentes;
        private IConsumidorEmpleado _ServicioEmpleado;

        public ComponentesController() : this(new ConsumidorActivo(), new ConsumidorCatalogos(), new ConsumidorUbicaciones(), new ConsumidorComponentes(), new ConsumidorEmpleado())  { }

        public ComponentesController(IConsumidorActivo servicio, IConsumidorCatalogos servicio2, IConsuidorUbicaciones servicio3, IConsumidorComponentes servicio4, IConsumidorEmpleado servicio5)
        {
            this._ServicioActivo = servicio;
            this._ServicioCatalogos = servicio2;
            this._ServicioUbicaciones = servicio3;
            this._ServicioComponentes = servicio4;
            this._ServicioEmpleado = servicio5;
        }



        // GET: Componentes
        
        public async Task<ActionResult> Index()
        {
            List<CatalogosViewModel> ListaEmpresas = new List<CatalogosViewModel>();
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 1, Nombre = "SERVICIOS INTEGRALES S.A" });
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 2, Nombre = "NEOTEC" });

            ViewBag.ListaEmpresas = ListaEmpresas;
            ViewBag.ListaUbicaciones = await _ServicioUbicaciones.ObtenerUbicaciones(2);
            
            return View(new List<ActivoViewModel>());
        }

        public async Task<JsonResult> MostrarActivos(string Empresa, int UbicacionId)
        {
            return Json(await _ServicioActivo.ObtenerActivosEmpresaUbicac(Empresa, UbicacionId), JsonRequestBehavior.AllowGet);
        }


        public ActionResult AgregandoComponente()        {
           

            return PartialView("_Componente");

        }


      


        public ActionResult AgregarComponentes(string SS, int ActivoId)
        {

            ViewBag.SActivo = SS;
            ViewBag.IdDelActivo = ActivoId;

            return View();
        }

   
        [HttpPost]
        public async Task<ActionResult> AgregarComponentes(GuardarComponentesViewModel Lista)
        {

            KeyValuePair<int, string> respuesta = new KeyValuePair<int, string>();

            

            foreach (var i in Lista.ListaComponentes)
            {
                i.IdActivo = Lista.IdActivo;
                respuesta  = await _ServicioComponentes.GuardarListaComponentes(i);
            }
                                

            if (respuesta.Value.Contains("Operacion Exitosa"))
            {
                TempData["Mensaje"] = new KeyValuePair<string, string>("success", "Los componentes se han registrado correctamente!!!");
                              
            }

            return RedirectToAction("Index");
        }


        public async Task<ActionResult> VerComponentes(int ActivoID)
        {
            var ActivoEncontrado = await _ServicioActivo.ObtenerActivoPorId(ActivoID);

            var NombreEmpleado = await _ServicioEmpleado.ObtenerEmpleado(ActivoEncontrado.NumEmpleado);

            ViewBag.SerieEnc = ActivoEncontrado.SerieImei;
            ViewBag.MarcaEnc = ActivoEncontrado.Marca;
            ViewBag.ModeloEnc = ActivoEncontrado.ModeloVersion;
            ViewBag.ProcesadorEnc = ActivoEncontrado.ProcesadorSim;
            ViewBag.DiscoEnc = ActivoEncontrado.DiscoDuroPlan;
            ViewBag.RamEnc = ActivoEncontrado.RamLinea;
            ViewBag.AsignadoEnc = NombreEmpleado.Nombre;
            ViewBag.ArticuloEnc = ActivoEncontrado.NombreArticulo;

            var ListaDeComponentesRepo = await _ServicioComponentes.ObtenerComponentesPorId(ActivoID);        

            return View(ListaDeComponentesRepo);
        }

    }

   
}
