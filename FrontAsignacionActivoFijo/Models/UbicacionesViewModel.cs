using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class UbicacionesViewModel
    {
        /// <summary>
        /// Obtiene o establece el id de la ubicacion
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ubicación
        /// </summary>
        [Display(Name = "Sucursal")]
        [Required(ErrorMessage = "El campo sucursal es requerido")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el id del municipio correspondiente a la ubicación
        /// </summary>
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo Municipio es requerido")]
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el estatus con el que se dara de alta la ubicación
        /// </summary>
        public bool Estatus { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estado para mostrarlo en la lista
        /// </summary>
        [Display(Name = "Estado")]    
        public string NombreEstado { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del municipio para mostrarlo en la lista
        /// </summary>
        [Display(Name = "Municipio")]
        public string NombreMunicipio { get; set; }
    }
}