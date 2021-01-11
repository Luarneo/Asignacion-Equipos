using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class Ubicacion : UbicacionVista
    {
        /// <summary>
        /// Obtiene o establece el id de la ubicacion
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ubicación
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el id del municipio correspondiente a la ubicación
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el estatus con el que se dara de alta la ubicación
        /// </summary>
        public bool Estatus { get; set; }

      
    }
}