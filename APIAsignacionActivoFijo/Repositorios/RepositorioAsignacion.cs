    using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioAsignacion : IRepositorioAsignacion
    {


        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");
        public  KeyValuePair<bool, string> GuardarActualizarAsignacion(Asignacion asignacion)
        {
            try
            {

                string CadSP = "dbo.[SP_GUARDAR_ASIGNACION]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdActivo", asignacion.IdActivo);
                cmd.Parameters.AddWithValue("@IdEstatus", asignacion.IdEstatus);
                cmd.Parameters.AddWithValue("@FechaAsignacion", asignacion.FechaAsignacion);
                cmd.Parameters.AddWithValue("@NumEmpleado", asignacion.NumEmpleado);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

                return new KeyValuePair<bool, string>(true, "Operación Exitosa");
                            

            }
            catch (Exception e)
            {
                return new KeyValuePair<bool, string>(false, e.Message);
            }
        }
    }
}