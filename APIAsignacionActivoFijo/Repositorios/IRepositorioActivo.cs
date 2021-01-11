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
        Task<List<ActivoVista>> ObtenerActivos(string Empresa, long UbicacionId);
        Task <KeyValuePair<bool,string>> GuardarActivo(Activo NuevoActivo);
        Task<ActivoVista> ObtenerActivo(int ActivoID);   
             
    }
}
