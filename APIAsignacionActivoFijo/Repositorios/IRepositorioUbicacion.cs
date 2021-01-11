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
        Task<List<Ubicacion>> ObtenerUbicaciones();
        Task<KeyValuePair<bool, string>> GuardarUbicacion(Ubicacion NuevaUbicacion);
        Task<KeyValuePair<bool, string>> ActualizarUbicaciones(int UbicacionId, bool Estatus);
        Task<List<Ubicacion>> ObtenerUbicacionesActivas();
    }
}
