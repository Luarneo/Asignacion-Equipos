using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioAsignacion
    {
        KeyValuePair<bool, string> GuardarActualizarAsignacion(Asignacion asignacion);
    }
}
