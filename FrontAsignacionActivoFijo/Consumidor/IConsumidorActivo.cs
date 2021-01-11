using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public interface IConsumidorActivo
    {
        Task<IEnumerable<ActivoViewModel>> ObtenerActivosEmpresaUbicac(string Empresa, long UbicacionId);
        Task<KeyValuePair<int, string>> GuardarActivo(ActivoViewModel NuevoActivo);
        Task<ActivoViewModel> ObtenerActivoPorId(int ActivoID);
        Task<KeyValuePair<int, string>> GuardarAsignacion(AsignacionViewModel NuevaAsignacion);
        Task<KeyValuePair<int, string>> CambiarEstatusActivo(int IdActivo, int estatus);
    }
}
