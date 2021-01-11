using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class Empleado
    {
        /// <summary>
        /// Obtiene o establece el nombre del empleado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el puesto del empleado
        /// </summary>
        public string Puesto { get; set; }

        /// <summary>
        /// Obtiene o establece la calle del domicilio del empleado
        /// </summary>
        public string Calle { get; set; }

        /// <summary>
        /// Obtiene o establece el numero del domicilio del empleado
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la colonia del domicilio del empleado
        /// </summary>
        public string Colonia { get; set; }

        /// <summary>
        /// Obtiene o establece el código postal del domicilio del empleado
        /// </summary>
        public string CP { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad del domicilio del empleado
        /// </summary>
        public string Ciudad { get; set; }

        /// <summary>
        /// Obtiene o establece las entre calles del domicilio del empleado
        /// </summary>
        public string EntreCalles { get; set; }

        /// <summary>
        /// Obtiene o establece numero de empleado
        /// </summary>
        public string NumEmpleadoE { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del centro de costo del empleado
        /// </summary>
        public string CentroCosto { get; set; }
    }
}