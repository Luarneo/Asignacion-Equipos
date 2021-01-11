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
    public class EmpleadoController : ApiController
    {

        private IRepositorioEmpleado _Repositorio;

        public EmpleadoController()
        {
            _Repositorio = new RepositorioEmpleado();
        }

        
        [HttpGet]
        public async Task<HttpResponseMessage> GetEmpleado(string NumeroEmpleado)
        {

            try
            {
                var EmpleadoObtenido = await _Repositorio.ObtenerEmpleado(NumeroEmpleado);

                if (EmpleadoObtenido != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, EmpleadoObtenido);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new Empleado() { NumEmpleadoE = "404", Nombre = "No se encontro el empleado" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new Empleado() { NumEmpleadoE = "500", Nombre = "Error interno: " + ex.Message });
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> PutEmpleado(Empleado empleado)
        {

            try
            {
                var RespuestaRepo = await _Repositorio.ActualizarEmpleado(empleado);

                if (RespuestaRepo.Key == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, RespuestaRepo);
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
