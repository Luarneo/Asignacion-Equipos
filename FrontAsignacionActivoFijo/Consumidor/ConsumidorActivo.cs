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
    public class ConsumidorActivo : IConsumidorActivo
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
        /// Obtiene activos filtrados por empresa y la ubicacion seleccionada
        /// </summary>
        /// <param name="Empresa"></param>
        /// <param name="UbicacionId"></param>
        /// <returns>devuelve objetos de tipo activos correspondientes</returns>
        public async Task<IEnumerable<ActivoViewModel>> ObtenerActivosEmpresaUbicac(string Empresa, long UbicacionId)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Articulo?Empresa={Empresa}&UbicacionId={UbicacionId}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActivoViewModel[]>(await json);
            }

            return new List<ActivoViewModel>();

        }

        /// <summary>
        /// Guarda en base de datos lis nuevos activos
        /// </summary>
        /// <param name="NuevoActivo"></param>
        /// <returns>devuelve respuesta si se guardo exitosamente o no</returns>
        public async Task<KeyValuePair<int, string>> GuardarActivo(ActivoViewModel NuevoActivo)
        {
            try
            {                
                using (var cliente = GetClient())
                {
                    HttpResponseMessage respuesta = await cliente.PostAsJsonAsync("api/Articulo", NuevoActivo);
                    
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
        /// Devuelve activo por filtro
        /// </summary>
        /// <param name="IdActivo"></param>
        /// <returns>Devuelve un solo objeto de tipo Activo por filtro de id ingresado</returns>
        public async Task<ActivoViewModel> ObtenerActivoPorId(int ActivoID)
        {
                
            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Articulo?ActivoID={ActivoID}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActivoViewModel>(await json);
            }

            return new ActivoViewModel();

        }

        /// <summary>
        /// Guarda datos de asignacion del activo
        /// </summary>
        /// <param name="NuevaAsignacion"></param>
        /// <returns>Devuelve respuesta si operacion ha sido exitosa o no</returns>
        public async Task<KeyValuePair<int, string>> GuardarAsignacion(AsignacionViewModel NuevaAsignacion)
        {
            try
            {
                
                using (var cliente = GetClient())
                {
                    HttpResponseMessage respuesta = await cliente.PostAsJsonAsync("api/Asignacion",  NuevaAsignacion);

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
        /// Actualiza en base de datos el estatus del activo
        /// </summary>
        /// <param name="IdActivo"></param>
        /// <param name="estatus"></param>
        /// <returns>Devuelve respuesta si operacion ha sido exitosa o no</returns>
        public async Task<KeyValuePair<int, string>> CambiarEstatusActivo(int IdActivo, int estatus)
        {
            
            try
            {

                using (var cliente = GetClient())
                {

                    var json = JsonConvert.SerializeObject(new
                    {
                        IdActivo,
                        estatus
                    });

                    HttpResponseMessage respuesta = await cliente.PutAsJsonAsync($"api/Articulo?IdActivo={IdActivo}&estatus={estatus}", new StringContent(json, Encoding.UTF8, "application/json"));

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