using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class ActivoVista : Activo
    {
       
        /// <summary>
        /// Obtiene o establece la descripcion de la clasificacion del activo
        /// </summary>
        public string NombreClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del articulo del activo
        /// </summary>
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del articulo del activo
        /// </summary>
        public string NumEmpleado { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de asignacion indicada por el usuario
        /// </summary>
        public DateTime? FechaAsignacion { get; set; }
    }
}
