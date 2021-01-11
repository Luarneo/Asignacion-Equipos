using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontAsignacionActivoFijo.Models;
using FrontAsignacionActivoFijo.Consumidor;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Controllers
{
    public class ActivoController : Controller
    {

        private IConsumidorActivo _ServicioActivo;
        private IConsumidorCatalogos _ServicioCatalogos;
        private IConsuidorUbicaciones _ServicioUbicaciones;

        public ActivoController() : this(new ConsumidorActivo(), new ConsumidorCatalogos(), new ConsumidorUbicaciones()) { }


        public ActivoController(IConsumidorActivo servicio, IConsumidorCatalogos servicio2, IConsuidorUbicaciones servicio3)
        {
            this._ServicioActivo = servicio;
            this._ServicioCatalogos = servicio2;
            this._ServicioUbicaciones = servicio3;
        }


        // GET: Activo/Create
        [Authorize]
        public async Task<ActionResult> NuevoActivo()
        {

            List<CatalogosViewModel> ListaEmpresas = new List<CatalogosViewModel>();
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 1, Nombre = "ECONTACT" });
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 2, Nombre = "SERVINEXT" });

            List<CatalogosViewModel> ListaDepartamentos = new List<CatalogosViewModel>();

            List<CatalogosViewModel> ListaArticulos = new List<CatalogosViewModel>();

            ViewBag.ListaEmpresas = ListaEmpresas;
            ViewBag.ListaAreas = await _ServicioCatalogos.ObtenerCatalogos(2);
            ViewBag.ListaDepartamentos = ListaDepartamentos;
            ViewBag.ListaUbicaciones = await _ServicioUbicaciones.ObtenerUbicaciones(2);
            ViewBag.ListaClasificaciones = await _ServicioCatalogos.ObtenerCatalogos(3);
            ViewBag.ListaArticulos= ListaArticulos;

            return View();
        }

        public async Task<JsonResult> ObtenerDepartamentos(int AreaId)
        {
            return Json(await _ServicioCatalogos.ObtenerDepartamentos(AreaId),JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ObtenerArticulos(int ClasificacionId)
        {
            return Json(await _ServicioCatalogos.ObtenerArticulos(ClasificacionId), JsonRequestBehavior.AllowGet);
        }

        // POST: Activo/Create
        [HttpPost]
        public async Task<ActionResult> NuevoActivo(ActivoViewModel NuevoActivo)
        {
            List<string> Datos = new List<string>();

            try
            {

                if (ModelState.IsValid)
                {
                    var resultado = await _ServicioActivo.GuardarActivo(NuevoActivo);

                    if (resultado.Value.Contains("Operacion Exitosa"))
                    {
                        TempData["Mensaje"] = new KeyValuePair<string, string>("success", "El activo se ha registrado correctamente !!!");
                        return RedirectToAction("NuevoActivo");

                    }
                    else
                    {

                        TempData["Mensaje"] = new KeyValuePair<string, string>("danger","Error al intentar guardar los datos del activo");
                        return RedirectToAction("NuevoActivo");                       
                    }
                }
                else
                {
                    TempData["Mensaje"] = new KeyValuePair<string, string>("danger", "Error: información incompleta");
                    return RedirectToAction("NuevoActivo");
              
                }

             
            }
            catch (Exception ex)
            {

                TempData["Mensaje"] = new KeyValuePair<string, string>("danger", "Error: " + ex.Message);
                return RedirectToAction("NuevoActivo");               

            }
        }        
    }
}
