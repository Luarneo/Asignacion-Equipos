using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontAsignacionActivoFijo.Models
{
    public class GuardarComponentesViewModel
    {
        public int IdActivo { get; set; }
        public List<ComponentesViewModel> ListaComponentes { get; set; }
    }
}