using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioCatalogos : IRepositorioCatalogos
    {

        public async  Task<List<Catalogo>> ObtenerEstados()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerEstados();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = i.EstadoID, Nombre = i.NombreEstado });
            }            

            return ListaFinal;
        }

        public async Task<List<Catalogo>> ObtenerMunicipios(int EstadoId)
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerMunicipio(Convert.ToInt16(EstadoId));

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.MunicipioID), Nombre = i.NombreMunicipio });
            }

            return ListaFinal;
        }

        public async Task<List<Catalogo>> ObtenerAreas()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();      

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerAreas();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.AreaID), Nombre = i.NombreArea});
            }
                     
            return ListaFinal;
        }

        public async Task<List<Catalogo>> ObtenerDepartamento(int AreaId)
        {
                       
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerDepartamento_areaID(Convert.ToInt16(AreaId));

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.DepartamentoID), Nombre = i.NombreDepartamento});
            }

            return ListaFinal;

        }

        public async Task<List<Catalogo>> ObtenerClasificacion()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerClasificaciones();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.ClasificacionID), Nombre = i.NombreClasificacion });
            }

            return ListaFinal;
        }

        public async Task<List<Catalogo>> ObtenerArticulo(int ClasificacionId)
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerArticulo_clasificaionID(Convert.ToInt16(ClasificacionId));

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.ArticuloID), Nombre = i.NombreArticulo});
            }

            return ListaFinal;
        }

        public async Task<List<Catalogo>> ObtenerEstatus()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerEstatus();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Catalogo() { Id = Convert.ToInt32(i.EstatusID), Nombre = i.Estatus});
            }

            return ListaFinal;
        }
            
    }
}