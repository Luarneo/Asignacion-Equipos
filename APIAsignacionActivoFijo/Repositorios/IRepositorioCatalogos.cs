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

        List<Catalogo> ObtenerEstados();
        List<Catalogo> ObtenerMunicipios(int EstadoId);
        List<Catalogo> ObtenerAreas();
        List<Catalogo> ObtenerDepartamento(int AreaId);
        List<Catalogo> ObtenerClasificacion();
        List<Catalogo> ObtenerArticulo(int ClasificacionId);
        List<Catalogo> ObtenerEstatus();
    }
}
