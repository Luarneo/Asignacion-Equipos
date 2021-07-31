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
    public class ComponenteController : ApiController
    {

        private IRepositorioComponente _Repositorio;

        public ComponenteController()
        {
            _Repositorio = new RepositorioComponente();
        }

       
        [HttpPost]
        public HttpResponseMessage PostComponente(Componente componente)
        {
            try
            {
                KeyValuePair<bool, string> respuestaRepo = _Repositorio.GuardarComponente(componente);

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

        [HttpGet]
        public HttpResponseMessage GetComponente(int ActivoID)
        {

            try
            {
                var ListaComponentes = _Repositorio.ObtenerComponentes(ActivoID);

                if (ListaComponentes.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaComponentes);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new List<Componente>());
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
    }
}
