using FrontAsignacionActivoFijo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public class ConsumidorEmpleado : IConsumidorEmpleado
    {
        private string WebApiUrl = ConfigurationManager.AppSettings["UrlApi"];

        private HttpClient GetClient()
        {
            var cliente = new HttpClient
            {
                BaseAddress = new Uri(WebApiUrl),
            };
            cliente.DefaultRequestHeaders.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return cliente;
        }

        private class Respuesta
        {
            public short Resultado { get; set; }
            public string Mensaje { get; set; }
        }

        /// <summary>
        /// Obtiene los datos de un empleado
        /// </summary>
        /// <param name="NumeroEmpleado">numero de empleado de quien se requiere sus datos</param>
        /// <returns>Datos del empleado</returns>
        public async Task<EmpleadoViewModel> ObtenerEmpleado(string NumeroEmpleado)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Empleado?NumeroEmpleado={NumeroEmpleado}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmpleadoViewModel>(await json);
            }

            return new EmpleadoViewModel();

        }

         
        //public async Task<string> ObtenerEmpleadoAsignado(int IdActivoAsignado)
        //{

        //    HttpResponseMessage resp;

        //    using (var cliente = GetClient())
        //    {
        //        resp = await cliente.GetAsync($"api/Empleado?IdActivoAsignado={IdActivoAsignado}");
        //    }

        //    if (resp.IsSuccessStatusCode)
        //    {
        //        var json = resp.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<string>(await json);
        //    }

        //    return null;
        //}

        /// <summary>
        /// Actualiza en base los datos de un empleado
        /// </summary>
        /// <param name="DatosEmpleado">modelo de datos a actualizar</param>
        /// <returns>respuesta de operación</returns>
        public async Task<KeyValuePair<int, string>> ActualizarEmpleado(EmpleadoViewModel DatosEmpleado)
        {
            try
            {

                using (var cliente = GetClient())
                {
                    HttpResponseMessage respuesta = await cliente.PutAsJsonAsync("api/Empleado", DatosEmpleado);

                    var content = respuesta.Content.ReadAsStringAsync();
                    var id = JsonConvert.DeserializeObject<Respuesta>(await content);

                    return new KeyValuePair<int, string>(id.Resultado, content.Result);
                }

            }
            catch (Exception e)
            {
                return new KeyValuePair<int, string>(-1, $"Error interno: {e}");
            }
        }
    }
}