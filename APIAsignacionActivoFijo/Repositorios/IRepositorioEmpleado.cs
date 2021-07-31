using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioEmpleado
    {
        Empleado ObtenerEmpleado(string NumeroEmpleado);
        KeyValuePair<bool, string> ActualizarEmpleado(Empleado empleado);
    }
}
