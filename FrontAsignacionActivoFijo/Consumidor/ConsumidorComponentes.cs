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
    public class ConsumidorComponentes : IConsumidorComponentes
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
        /// Guarda datos de un solo componente
        /// </summary>
        /// <param name="Componente">Modelo que contiene los datos del componente a guardar</param>
        /// <returns>Respuesta de operación</returns>
        public async Task<KeyValuePair<int, string>> GuardarListaComponentes(ComponentesViewModel Componente)
        {
            try
            {

                using (var cliente = GetClient())
                {

                    HttpResponseMessage resp = await cliente.PostAsJsonAsync("api/Componente", Componente);
                    var content = resp.Content.ReadAsStringAsync();

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
        /// Muestra lista de componentes correspondientes a un activo
        /// </summary>
        /// <param name="ActivoID">id del activo del que se requiere la lista de componentes</param>
        /// <returns>Lista de componentes correspondiente al id de activo ingresado</returns>
        public async Task<IEnumerable<ComponentesViewModel>> ObtenerComponentesPorId(int ActivoID)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Componente?ActivoID={ActivoID}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ComponentesViewModel[]>(await json);
            }

            return new List<ComponentesViewModel>();

        }
    }
}