using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {

        public async Task<Empleado> ObtenerEmpleado(string NumeroEmpleado)
        {

            Empleado EmpleadoFinal = new Empleado();          

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var RespuestaObj = respuesta.ObtenerEmpleado(NumeroEmpleado);

            //EmpleadoFinal.NumEmpleadoE = RespuestaObj.
            EmpleadoFinal.Nombre = RespuestaObj.Asignacion;
            EmpleadoFinal.Puesto = RespuestaObj.Puesto;
            EmpleadoFinal.Calle = RespuestaObj.Calle;
            EmpleadoFinal.Numero = RespuestaObj.Numero;
            EmpleadoFinal.Colonia = RespuestaObj.Colonia;
            EmpleadoFinal.Ciudad = RespuestaObj.Ciudad;
            EmpleadoFinal.CP = RespuestaObj.CP;
            EmpleadoFinal.EntreCalles = RespuestaObj.EntreCalles;
            EmpleadoFinal.CentroCosto = RespuestaObj.CentroCostos;
            EmpleadoFinal.NumEmpleadoE = RespuestaObj.ColaboradorID;



            //if (NumeroEmpleado == "E000001")
            //{
            //    EmpleadoFinal.NumEmpleadoE = "E000001";
            //    EmpleadoFinal.Nombre = "JUAN PEREZ";
            //    EmpleadoFinal.Puesto = "SUPERVISOR";
            //    EmpleadoFinal.Calle = "CALLE INDEPENDENCIA";
            //    EmpleadoFinal.Numero = "23";
            //    EmpleadoFinal.Colonia = "CENTRO";
            //    EmpleadoFinal.Ciudad = "PUEBLA";
            //    EmpleadoFinal.CP = "72000";
            //    EmpleadoFinal.EntreCalles = "2 Y 4 PONIENTE";
            //    EmpleadoFinal.CentroCosto = "TELCEL";
            //}

            //if (NumeroEmpleado == "E000002")
            //{
            //    EmpleadoFinal.NumEmpleadoE = "E000002";
            //    EmpleadoFinal.Nombre = "LOLA LOPEZ";
            //    EmpleadoFinal.Puesto = "ADMINISTRADORA";
            //    EmpleadoFinal.Calle = "AV. LIBERTAD";
            //    EmpleadoFinal.Numero = "500";
            //    EmpleadoFinal.Colonia = "CENTRO";
            //    EmpleadoFinal.Ciudad = "CHOLULA";
            //    EmpleadoFinal.CP = "72309";
            //    EmpleadoFinal.EntreCalles = "20 DE NOVIEMBRE Y 5 DE MAYO";
            //    EmpleadoFinal.CentroCosto = "FINANZAS";

            //}

            return EmpleadoFinal;
        }

      
        public async Task<KeyValuePair<bool, string>> ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                               
                ACTIVOS_FIJOS.Datos Data = new ACTIVOS_FIJOS.Datos();

                var Respuesta = Data.ActualizarEmpleado(new ACTIVOS_FIJOS.Colaborador()
                {
                    Calle = empleado.Calle,
                    Ciudad = empleado.Ciudad,
                    Colonia = empleado.Colonia,
                    CP = empleado.CP,
                    EntreCalles = empleado.EntreCalles,
                    Numero = empleado.Numero,
                    Asignacion = empleado.Nombre,
                    CentroCostos = empleado.CentroCosto,
                    ColaboradorID = empleado.NumEmpleadoE,
                    Puesto = empleado.Puesto
                
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