using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class EmpleadoViewModel
    {
        /// <summary>
        /// Obtiene o establece el nombre del empleado
        /// </summary>
        [Display(Name = "Asignación")]
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
        [Display(Name = "Número")]
        public string Numero { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la colonia del domicilio del empleado
        /// </summary>
        public string Colonia { get; set; }

        /// <summary>
        /// Obtiene o establece el código postal del domicilio del empleado
        /// </summary>
        [Display(Name = "C.P.")]
        public string CP { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad del domicilio del empleado
        /// </summary>
        public string Ciudad { get; set; }

        /// <summary>
        /// Obtiene o establece las entre calles del domicilio del empleado
        /// </summary>
        [Display(Name = "Entre calles")]
        public string EntreCalles { get; set; }

        /// <summary>
        /// Obtiene o establece numero de empleado
        /// </summary>
        [Display(Name = "Num. colaborador")]
        public string NumEmpleadoE { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del centro de costo del empleado
        /// </summary>
        [Display(Name = "Centro de costo")]
        public string CentroCosto { get; set; }
    }
}