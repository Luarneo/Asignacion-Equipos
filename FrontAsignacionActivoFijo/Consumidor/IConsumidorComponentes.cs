using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public interface IConsumidorComponentes
    {
        Task<KeyValuePair<int, string>> GuardarListaComponentes(ComponentesViewModel Componente);
        Task<IEnumerable<ComponentesViewModel>> ObtenerComponentesPorId(int ActivoID);
    }
}
