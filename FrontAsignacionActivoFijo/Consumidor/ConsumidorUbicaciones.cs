using FrontAsignacionActivoFijo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public class ConsumidorUbicaciones:IConsuidorUbicaciones
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

        // <summary>
        /// Respuesta satisfactoria de una petición HTTP
        /// </summary>
        private class Respuesta
        {
            public short Resultado { get; set; }
            public string Mensaje { get; set; }
        }

               
       /// <summary>
       /// Muesta ubicaciones existentes en base
       /// </summary>
       /// <param name="Filtro">1: todas las ubicaciones, 2: solo ubicaciones activas</param>
       /// <returns>Listados de ubicaciones de acuerdo a filtro ingresado</returns>
        public async Task<IEnumerable<UbicacionesViewModel>> ObtenerUbicaciones(int Filtro)
            {


            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Ubicacion?Filtro={Filtro}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UbicacionesViewModel[]>(await json);
            }

            return new List<UbicacionesViewModel>();

        }

        /// <summary>
        /// Guarda en base de datos los datos de una nueva ubicación
        /// </summary>
        /// <param name="IdMunicipio"></param>
        /// <param name="Nombre"></param>
        /// <param name="Estatus"></param>
        /// <returns>Devuelve si operación fue exitosa o no</returns>
        public async Task<KeyValuePair<int, string>> GuardarUbicacion(UbicacionesViewModel NuevaUbicacion)
        {
            try
            {


                using (var cliente = GetClient())
                {
                    HttpResponseMessage respuesta = await cliente.PostAsJsonAsync("api/Ubicacion", NuevaUbicacion);

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



        /// <summary>
        /// Actualiza en estatus (activo o inactivo) de la ubicación
        /// </summary>
        /// <param name="IdUbicacion"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        public async Task<KeyValuePair<int, string>> CambiarEstatusUbicacion(int IdUbicacion, bool estatus)
        {
            try
            {

                using (var cliente = GetClient())
                {
                    var json = JsonConvert.SerializeObject(new
                    {
                        IdUbicacion,
                        estatus
                    });                   

                    HttpResponseMessage respuesta = await cliente.PutAsJsonAsync($"api/Ubicacion?IdUbicacion={IdUbicacion}&estatus={estatus}", new StringContent(json, Encoding.UTF8, "application/json"));

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