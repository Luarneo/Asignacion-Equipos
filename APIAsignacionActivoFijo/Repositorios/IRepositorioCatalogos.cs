using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioCatalogos
    {

        Task<List<Catalogo>> ObtenerEstados();
        Task<List<Catalogo>> ObtenerMunicipios(int EstadoId);        
        Task<List<Catalogo>> ObtenerAreas();
        Task<List<Catalogo>> ObtenerDepartamento(int AreaId);
        Task<List<Catalogo>> ObtenerClasificacion();
        Task<List<Catalogo>> ObtenerArticulo(int ClasificacionId);
        Task<List<Catalogo>> ObtenerEstatus();
    }
}
