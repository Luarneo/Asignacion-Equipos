using FrontAsignacionActivoFijo.Consumidor;
using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontAsignacionActivoFijo.Controllers
{
    public class UbicacionesController : Controller
    {

        private IConsuidorUbicaciones _ServicioUbicaciones;
        private IConsumidorCatalogos _ServicioCatalogos;

        public UbicacionesController() : this(new ConsumidorUbicaciones(), new ConsumidorCatalogos()) { }
        

        public UbicacionesController(IConsuidorUbicaciones servicio, IConsumidorCatalogos servicio2)
        {
            this._ServicioUbicaciones = servicio;
            this._ServicioCatalogos = servicio2;
        }

        // GET: Ubicaciones
        [Authorize]
        public async Task<ActionResult>  Index()
        {

            //Obtiene lista de estados
            ViewBag.ListaEstados = await _ServicioCatalogos.ObtenerCatalogos(1);
            var ListaUbicaciones = await _ServicioUbicaciones.ObtenerUbicaciones(1);

            
            return View(ListaUbicaciones);
        }

        public async Task<PartialViewResult> NuevaUbicacion()
        {
            ViewBag.ListaEstados = await _ServicioCatalogos.ObtenerCatalogos(1);
            ViewBag.ListaMunicipios = new List<CatalogosViewModel>();
         
            return PartialView("_NuevaUbicacion",new UbicacionesViewModel());

        }

        public async Task<JsonResult> ObtenerMunicipios(int EstadoId)
        {           
            return Json(await _ServicioCatalogos.ObtenerMunicipios(EstadoId), JsonRequestBehavior.AllowGet);
        }

        // POST: Ubicaciones/Create
        [HttpPost]       
        public async Task<JsonResult> GuardarNuevaUbicacion(UbicacionesViewModel NuevaUbicacion)
        {
            List<string> Datos = new List<string>();

            try
            {

                if (ModelState.IsValid)
                {
                    var resultado = await _ServicioUbicaciones.GuardarUbicacion(NuevaUbicacion);

                    if (resultado.Value.Contains("Operacion Exitosa"))
                    {
                        Datos.Add("success");
                        Datos.Add("La ubicación se guardo correctamente !!!");

                    }
                    else
                    {
                        Datos.Add("danger");
                        Datos.Add("Error al intentar guardar la ubicación");
                    }
                }
                else
                {
                    Datos.Add("danger");
                    Datos.Add("Error: información incompleta");
                }

                return Json(Datos);
            }
            catch (Exception ex)
            {
                Datos.Add("danger");
                Datos.Add("Error:" + ex.Message);

                return Json(Datos);
            }
                      
        }


        public JsonResult ActualizarEstatusUbicacion(int IdUbicacion, bool estatus)
        {
            var respuesta = _ServicioUbicaciones.CambiarEstatusUbicacion(IdUbicacion, estatus);
            return null;
        }

        
        
    }
}
