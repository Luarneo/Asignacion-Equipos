using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class AsignacionViewModel
    {
        /// <summary>
        /// Obtiene o establece el id del activo que se asigna
        /// </summary>
        public int IdActivo { get; set; }

        /// <summary>
        /// Obtiene o establece el id del estatus
        /// </summary>
        [Display(Name = "Estatus")]
        public int IdEstatus { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se asigna el ativo
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaAsignacion { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de empleado al cual se asigna
        /// </summary>
        [Display(Name = "Número de colaborador")]
        public string NumEmpleado { get; set; }
    }
}