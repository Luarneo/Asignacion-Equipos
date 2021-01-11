using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioAsignacion : IRepositorioAsignacion
    {
        public async Task<KeyValuePair<bool, string>> GuardarActualizarAsignacion(Asignacion asignacion)
        {
            try
            {
                ACTIVOS_FIJOS.Datos Data = new ACTIVOS_FIJOS.Datos();

                var Respuesta = Data.GuardarActualizarAsignacion(new ACTIVOS_FIJOS.Asignacion()
                {
                    ActivoID = asignacion.IdActivo,
                    Colaborador = asignacion.NumEmpleado,
                    EstatusID = asignacion.IdEstatus,
                    FechaEstatus = asignacion.FechaAsignacion               
                    
                });

                if (Respuesta.Bandera == 1)
                {
                    return new KeyValuePair<bool, string>(true, "Operacion Exitosa");
                }
                else
                {
                    return new KeyValuePair<bool, string>(true, Respuesta.Mensaje);
                }

            }
            catch (Exception e)
            {
                return new KeyValuePair<bool, string>(false, e.Message);
            }
        }
    }
}