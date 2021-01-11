using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public interface IConsuidorUbicaciones
    {
        Task<IEnumerable<UbicacionesViewModel>> ObtenerUbicaciones(int Filtro);
        Task<KeyValuePair<int, string>> GuardarUbicacion(UbicacionesViewModel NuevaUbicacion);
        Task<KeyValuePair<int, string>> CambiarEstatusUbicacion(int IdUbicacion, bool estatus);

    }
}
