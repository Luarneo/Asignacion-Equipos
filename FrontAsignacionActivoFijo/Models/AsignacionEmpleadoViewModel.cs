using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class AsignacionEmpleadoViewModel
    {
        /// <summary>
        /// Obtiene o establece el id del activo que se asigna
        /// </summary>       
        public int IdActivo { get; set; }

        /// <summary>
        /// Obtiene o establece el id del estatus
        /// </summary>
        [Required(ErrorMessage = "El campo Estatus es requerido")]
        [Display(Name = "Estatus")]
        public int IdEstatus { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en la que se asigna el ativo
        /// </summary>
        [Required(ErrorMessage = "El campo Fecha es requerido")]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "0:dd/MM/yyyy}")]
        [Display(Name = "Fecha")]
        public DateTime FechaAsignacion { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de empleado al cual se asigna
        /// </summary>         
        [Display(Name = "Número de colaborador")]
        public string NumEmpleadoA { get; set; }

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
        [Required(ErrorMessage = "Es necesario asignar un colaborador")]
        public string NumEmpleadoE { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del centro de costo del empleado
        /// </summary>
        [Display(Name = "Centro de costo")]
        public string CentroCosto { get; set; }

        /// <summary>
        /// Indica si se genero alguna actuaización del empleado
        /// </summary>     
        public bool ActualizacionEmpleado { get; set; }

        /// <summary>
        /// Indica si se genero alguna actuaización del empleado
        /// </summary>     
        public string ArticuloA { get; set; }
    }
}