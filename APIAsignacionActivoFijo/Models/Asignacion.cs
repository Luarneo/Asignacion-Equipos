using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class Asignacion
    {
        /// <summary>
        /// Obtiene o establece el id del activo que se asigna
        /// </summary>
        public int IdActivo { get; set; }

        /// <summary>
        /// Obtiene o establece el id del estatus
        /// </summary>
        public int IdEstatus { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se asigna el ativo
        /// </summary>
        public DateTime FechaAsignacion { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de empleado al cual se asigna
        /// </summary>
        public string NumEmpleado { get; set; }
    }
}