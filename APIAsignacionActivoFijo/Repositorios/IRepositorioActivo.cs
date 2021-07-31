using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioActivo
    {
        List<ActivoVista> ObtenerActivos(string Empresa, long UbicacionId);
        KeyValuePair<bool,string> GuardarActivo(Activo NuevoActivo);
        ActivoVista ObtenerActivo(int ActivoID);   
             
    }
}
