using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAsignacionActivoFijo.Repositorios
{
    public interface IRepositorioComponente
    {
        KeyValuePair<bool, string> GuardarComponente(Componente ListaComponentes);
        List<Componente> ObtenerComponentes(int ActivoID);
    }
}
