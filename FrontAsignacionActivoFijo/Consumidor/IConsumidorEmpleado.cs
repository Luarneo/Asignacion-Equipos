using FrontAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAsignacionActivoFijo.Consumidor
{
    public interface IConsumidorEmpleado
    {
        //Task<string> ObtenerEmpleadoAsignado(int IdActivoAsignado);
        Task<EmpleadoViewModel> ObtenerEmpleado(string NumeroEmpleado);
        Task<KeyValuePair<int, string>> ActualizarEmpleado(EmpleadoViewModel empleado);
    }
}
