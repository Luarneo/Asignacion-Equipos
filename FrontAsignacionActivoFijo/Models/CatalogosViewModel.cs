﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class CatalogosViewModel
    {
        /// <summary>
        /// Obtiene o establece el Id de los elementos del catalogo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de los elementos del catalogo
        /// </summary>
        public string Nombre { get; set; }
    }
}