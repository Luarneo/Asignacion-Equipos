using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public interface IConsumidorCatalogos
    {
        Task<IEnumerable<CatalogosViewModel>> ObtenerCatalogos(int filtro);
        Task<IEnumerable<CatalogosViewModel>> ObtenerMunicipios(int IdEstado);
        Task<IEnumerable<CatalogosViewModel>> ObtenerDepartamentos(int IdArea);
        Task<IEnumerable<CatalogosViewModel>> ObtenerArticulos(int IdClasificacion);
    }
}
