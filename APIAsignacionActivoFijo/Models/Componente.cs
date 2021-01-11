using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class Componente
    {
        /// <summary>
        /// Obtiene o establece el id del componente
        /// </summary>
        public int IdComponente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del componente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la marca del componente
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo del componente
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Obtiene o establece la serie del componente
        /// </summary>
        public string Serie { get; set; }

        /// <summary>
        /// Obtiene o establece el procesador del componente
        /// </summary>
        public string Procesador { get; set; }

        /// <summary>
        /// Obtiene o establece el disco duro del componente
        /// </summary>
        public string DiscoDuro { get; set; }

        /// <summary>
        /// Obtiene o establece la memoria ram del componente
        /// </summary>
        public string Ram { get; set; }

        /// <summary>
        /// Obtiene o establece las anotaciones 
        /// </summary>
        public string Anotaciones{ get; set; }

        /// <summary>
        /// Obtiene o establece el id del activo al cual se da de alta el componente
        /// </summary>
        public int IdActivo { get; set; }
    }
}