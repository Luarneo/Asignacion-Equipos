using APIAsignacionActivoFijo.Models;
using APIAsignacionActivoFijo.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIAsignacionActivoFijo.Controllers
{
    public class ArticuloController : ApiController
    {

        private IRepositorioActivo _RepositorioActivo;
        private IRepositorioAsignacion _RepositorioAsignacion;


        //public ArticuloController(IRepositorioActivo servicio1, IRepositorioAsignacion servicio2)
        //{           
        //    _RepositorioActivo = servicio1;
        //    _RepositorioAsignacion = servicio2;
        //}

        public ArticuloController()
        {
            _RepositorioActivo = new RepositorioActivo();
            _RepositorioAsignacion = new RepositorioAsignacion();
        }


        [HttpPost]
        public async Task<HttpResponseMessage> PostActivo(Activo activo)
        {
            try
            {
             
                KeyValuePair<bool, string> respuestaRepo = await _RepositorioActivo.GuardarActivo(activo);

                if (respuestaRepo.Key == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respuestaRepo);
                }

                throw new Exception(respuestaRepo.Value);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActivo(string Empresa, long UbicacionId)
        {
            try
            {
                var ListaActivos = await _RepositorioActivo.ObtenerActivos(Empresa, UbicacionId);

                if (ListaActivos.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaActivos);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new List<ActivoVista>());
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActivo(int ActivoID)
        {
            try
            {
                var ListaActivos = await _RepositorioActivo.ObtenerActivo(ActivoID);

                if (ListaActivos != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaActivos);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new ActivoVista());
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Asignacion")]
        public async Task<HttpResponseMessage> PostAsignacion(Asignacion asignacion)
        {
            try
            {
                KeyValuePair<bool, string> respuestaRepo = await _RepositorioAsignacion.GuardarActualizarAsignacion(asignacion);

                if (respuestaRepo.Key == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respuestaRepo);
                }

                throw new Exception(respuestaRepo.Value);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
