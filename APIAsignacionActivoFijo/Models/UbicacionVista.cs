using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class UbicacionVista
    {
        /// <summary>
        /// Obtiene o establece el nombre del estado para mostrarlo en la lista
        /// </summary>
        public string NombreEstado { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del municipio para mostrarlo en la lista
        /// </summary>
        public string NombreMunicipio { get; set; }
    }
}