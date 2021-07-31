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
    public class UbicacionController : ApiController
    {

        private IRepositorioUbicacion _Repositorio;

        public UbicacionController()
        {
            _Repositorio = new RepositorioUbicacion();
        }

        
       
        [HttpGet]
        public HttpResponseMessage GetUbicacion(int Filtro) 
        {

            try
            {

                List<Ubicacion> ListaUbicaciones = new List<Ubicacion>();

                //Todas las Ubicaciones  
                if (Filtro == 1)
                {
                    ListaUbicaciones = _Repositorio.ObtenerUbicaciones();
                    
                }

                //Solo Ubicaciones activas    
                else if (Filtro == 2)
                {
                    ListaUbicaciones = _Repositorio.ObtenerUbicacionesActivas();
                }

                else
                {
                    ListaUbicaciones = new List<Ubicacion>();

                }

                if (ListaUbicaciones.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaUbicaciones);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new List<Ubicacion>());
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
    
        [HttpPost]
        public HttpResponseMessage PostUbicacion (Ubicacion NuevaUbicacion) 
        {
            try
            {
                KeyValuePair<bool, string> respuestaRepo = _Repositorio.GuardarUbicacion(NuevaUbicacion);
                
                if (respuestaRepo.Key==true)
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

        [HttpPut]
        public HttpResponseMessage PutUbicacion(int IdUbicacion, bool Estatus) 
        {
            try
            {
                KeyValuePair<bool, string> respuestaRepo = _Repositorio.ActualizarUbicaciones(IdUbicacion, Estatus);

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
