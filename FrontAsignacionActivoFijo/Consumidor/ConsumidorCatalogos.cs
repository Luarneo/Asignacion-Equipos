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
    public class ConsumidorCatalogos : IConsumidorCatalogos
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

        /// <summary>
        /// Devuelve catalogos dependiendo del filtro ingresado
        /// </summary>
        /// <param name="filtro">1: Estados, 2: Areas, 3: Clasificaciones, 4: Estatus</param>
        /// <returns>Lista de objetos de tipo Catalogo</returns>
        public async Task<IEnumerable<CatalogosViewModel>> ObtenerCatalogos(int filtro)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Catalogos?filtro={filtro}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatalogosViewModel[]>(await json);
            }

            return new List<CatalogosViewModel>();

        }

        /// <summary>
        /// Muestra lista de municipios registrados en base
        /// </summary>
        /// <param name="EstadoId">id del estado seleccionado</param>
        /// <returns>id y nombre de municipios</returns>
        public async Task<IEnumerable<CatalogosViewModel>> ObtenerMunicipios(int EstadoId)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Catalogos?EstadoId={EstadoId}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatalogosViewModel[]>(await json);
            }

            return new List<CatalogosViewModel>();

        }

        /// <summary>
        /// Muestra lista de departamentos de la empresa existentes en la base
        /// </summary>
        /// <param name="AreaId">id del area al que corresponde el grupo de departamentos</param>
        /// <returns>lista de departamentos correspondientes</returns>
        public async Task<IEnumerable<CatalogosViewModel>> ObtenerDepartamentos(int AreaId)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Catalogos?AreaId={AreaId}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatalogosViewModel[]>(await json);
            }

            return new List<CatalogosViewModel>();

        }

        /// <summary>
        /// Muestra articulos correspondientes
        /// </summary>
        /// <param name="ClasificacionId">id de  clasificacion</param>
        /// <returns>lista de articulos correspondientes al id de la clasificacion ingresado</returns>
        public async Task<IEnumerable<CatalogosViewModel>> ObtenerArticulos(int ClasificacionId)
        {

            HttpResponseMessage resp;
            using (var cliente = GetClient())
            {
                resp = await cliente.GetAsync($"api/Catalogos?ClasificacionId={ClasificacionId}");
            }

            if (resp.IsSuccessStatusCode)
            {
                var json = resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatalogosViewModel[]>(await json);
            }

            return new List<CatalogosViewModel>();

        }


    }
}