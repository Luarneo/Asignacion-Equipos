using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class ActivoViewModel
    {
        /// <summary>
        /// Obtiene o establece el Id del Activo
        /// </summary>
        public int IdActivo { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de la empresa a la que se da de alta el activo
        /// </summary>
        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Empresa { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del area a la que se da de alta el activo
        /// </summary>
        [Display(Name = "Área")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdArea { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del departamento que se da de  alta en el activo
        /// </summary>
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdDepartamento { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de la ubicación que se da de alta en el activo
        /// </summary>
        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdUbicacion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de la clasificación que se da de alta en el activo
        /// </summary>
        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del articulo que se da de alta en el activo
        /// </summary>
        [Display(Name = "Artículo")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdArticulo { get; set; }

        /// <summary>
        /// Obtiene o establece la marca del articulo que se registra al activo
        /// </summary>
       
        [Required(ErrorMessage = "Campo requerido")]
        public string Marca { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo o version del articulo que se registra al activo
        /// </summary>
        [Display(Name = "Modelo / Versión")]
        [Required(ErrorMessage = "Campo requerido")]
        public string ModeloVersion { get; set; }

        /// <summary>
        /// Obtiene o establece el procesador o sim del articulo que se registra al activo
        /// </summary>
        [Display(Name = "Procesador / Sim")]
        [Required(ErrorMessage = "Campo requerido")]
        public string ProcesadorSim { get; set; }

        /// <summary>
        /// Obtiene o establece el disco duro o plan del articulo que se registra al activo
        /// </summary>
        [Display(Name = "Disco duro / Plan ")]
        [Required(ErrorMessage = "Campo requerido")]
        public string DiscoDuroPlan { get; set; }

        /// <summary>
        /// Obtiene o establece la ram o la linea del articulo que se registra al activo
        /// </summary>
        [Display(Name = "RAM / Línea")]
        [Required(ErrorMessage = "Campo requerido")]
        public string RamLinea { get; set; }

        /// <summary>
        /// Obtiene o establece la serie o el imei del articulo que se registra al activo
        /// </summary>
        [Display(Name = "Número Serie / IMEI")]
        [Required(ErrorMessage = "Campo requerido")]
        public string SerieImei { get; set; }

        /// <summary>
        /// Obtiene o establece las observaciones del activo
        /// </summary>
        [Display(Name = "Descripción / Observaciones")]
        [Required(ErrorMessage = "Campo requerido")]
        //[Required(ErrorMessage = "El campo Descripción / Observaciones es requerido")]
        public string Obervaciones { get; set; }

    
        /// <summary>
        /// Obtiene o establece la descripcion de la clasificacion del activo
        /// </summary>
        public string NombreClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion del articulo del activo
        /// </summary>
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Obtiene o establece el numero de empleado del activo asignado
        /// </summary>
        public string NumEmpleado { get; set; }

        /// <summary>
        /// Obtiene la fecha de asignación del activo
        /// </summary>
        public DateTime? FechaAsignacion { get; set; }
    }
}
