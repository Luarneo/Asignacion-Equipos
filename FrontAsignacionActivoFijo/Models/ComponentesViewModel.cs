using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HtmlHelpers.BeginCollectionItem;

namespace FrontAsignacionActivoFijo.Models
{
    public class ComponentesViewModel
    {
        /// <summary>
        /// Obtiene o establece el id del componente
        /// </summary>
        public int IdComponente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del componente
        /// </summary>
        [Display(Name = "Componente")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la marca del componente
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string Marca { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo del componente
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string Modelo { get; set; }

        /// <summary>
        /// Obtiene o establece la serie del componente
        /// </summary>
        [Display(Name = "No. Serie / Parte")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Serie { get; set; }

        /// <summary>
        /// Obtiene o establece el procesador del componente
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string Procesador { get; set; }

        /// <summary>
        /// Obtiene o establece el disco duro del componente
        /// </summary>
        [Display(Name = "Disco duro")]
        [Required(ErrorMessage = "Campo requerido")]
        public string DiscoDuro { get; set; }

        /// <summary>
        /// Obtiene o establece la memoria ram del componente
        /// </summary>
        [Display(Name = "RAM")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Ram { get; set; }

        /// <summary>
        /// Obtiene o establece las anotaciones 
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string Anotaciones { get; set; }

        /// <summary>
        /// Obtiene o establece el id del activo al cual se asigna el componente 
        /// </summary>    
        public int IdActivo { get; set; }


    }
}