using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioUbicacion
    {
        List<Ubicacion> ObtenerUbicaciones();
        KeyValuePair<bool, string> GuardarUbicacion(Ubicacion NuevaUbicacion);
        KeyValuePair<bool, string> ActualizarUbicaciones(int UbicacionId, bool Estatus);
        List<Ubicacion> ObtenerUbicacionesActivas();
    }
}
