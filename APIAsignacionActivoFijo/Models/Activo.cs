using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAsignacionActivoFijo.Models
{
    public class Activo
    {
        /// <summary>
        /// Obtiene o establece el Id del Activo
        /// </summary>
        public int IdActivo { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de la empresa a la que se da de alta el activo
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del area a la que se da de alta el activo
        /// </summary>
        public int IdArea { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del departamento que se da de  alta en el activo
        /// </summary>
        public int IdDepartamento { get; set; }
        
        /// <summary>
        /// Obtiene o establece el Id de la ubicación que se da de alta en el activo
        /// </summary>
        public int IdUbicacion { get; set; }
        
        /// <summary>
        /// Obtiene o establece el Id de la clasificación que se da de alta en el activo
        /// </summary>
        public int IdClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del articulo que se da de alta en el activo
        /// </summary>
        public int IdArticulo { get; set; }

        /// <summary>
        /// Obtiene o establece la marca del articulo que se registra al activo
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo o version del articulo que se registra al activo
        /// </summary>
        public string ModeloVersion { get; set; }

        /// <summary>
        /// Obtiene o establece el procesador o sim del articulo que se registra al activo
        /// </summary>
        public string ProcesadorSim { get; set; }

        /// <summary>
        /// Obtiene o establece el disco duro o plan del articulo que se registra al activo
        /// </summary>
        public string DiscoDuroPlan { get; set; }

        /// <summary>
        /// Obtiene o establece la ram o la linea del articulo que se registra al activo
        /// </summary>
        public string RamLinea { get; set; }

        /// <summary>
        /// Obtiene o establece la serie o el imei del articulo que se registra al activo
        /// </summary>
        public string SerieImei { get; set; }

        /// <summary>
        /// Obtiene o establece la serie o el imei del articulo que se registra al activo
        /// </summary>
        public string Observaciones { get; set; }


    }
}
