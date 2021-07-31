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
    public class CatalogosController : ApiController
    {
        private IRepositorioCatalogos _Repositorio;

        public CatalogosController()
        {
            _Repositorio = new RepositorioCatalogos();
        }

        
        [HttpGet]
        public HttpResponseMessage GetObtenerCatalogos( int filtro)
        {

            try
            {
                var ListaFinal = new List<Catalogo>();

                if (filtro == 1)
                {
                    ListaFinal = _Repositorio.ObtenerEstados();
                }

                if (filtro == 2)
                {
                    ListaFinal = _Repositorio.ObtenerAreas();
                }

                if (filtro == 3)
                {
                    ListaFinal =  _Repositorio.ObtenerClasificacion();
                }

                if (filtro == 4)
                {
                    ListaFinal =  _Repositorio.ObtenerEstatus();
                }

                
                if (ListaFinal.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaFinal);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetObtenerMunicipios(int EstadoId)
        {
            try
            {
                var ListaFinal = _Repositorio.ObtenerMunicipios(EstadoId);

                if (ListaFinal.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaFinal);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        
        [HttpGet]
        public HttpResponseMessage GetObtenerDepartamentos(int AreaId)
        {
            try
            {
                var ListaFinal = _Repositorio.ObtenerDepartamento(AreaId);

                if (ListaFinal.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaFinal);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetObtenerArticulos(int ClasificacionId)
        {
            try
            {
                var ListaFinal = _Repositorio.ObtenerArticulo(ClasificacionId);

                if (ListaFinal.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListaFinal);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }
}
