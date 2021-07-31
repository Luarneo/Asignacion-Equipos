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
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");
        public Empleado ObtenerEmpleado(string NumeroEmpleado)
        {

       
            string CadSP = "[dbo].[SP_OBTENER_EMPLEADO]";

            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroEmpleado", NumeroEmpleado);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            Empleado EmpleadoFinal = new Empleado();

            EmpleadoFinal.NumEmpleadoE = dt.Rows[0]["Colaborador"].ToString();
            EmpleadoFinal.Nombre = dt.Rows[0]["Asignacion"].ToString();
            EmpleadoFinal.Puesto = dt.Rows[0]["Puesto"].ToString();
            EmpleadoFinal.CentroCosto = dt.Rows[0]["CentroCostos"].ToString();         
            EmpleadoFinal.Calle = dt.Rows[0]["Calle"].ToString();
            EmpleadoFinal.Numero = dt.Rows[0]["Numero"].ToString();
            EmpleadoFinal.Ciudad = dt.Rows[0]["Ciudad"].ToString();
            EmpleadoFinal.Colonia = dt.Rows[0]["Colonia"].ToString();
            EmpleadoFinal.CP = dt.Rows[0]["CP"].ToString();
            EmpleadoFinal.EntreCalles = dt.Rows[0]["EntreCalles"].ToString();

            return EmpleadoFinal;
        }

      
        public KeyValuePair<bool, string> ActualizarEmpleado(Empleado empleado)
        {
            try
            {

                string CadSP = "dbo.[SP_ACTUALIZAR_EMPLEADO]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
                cmd.Parameters.AddWithValue("@Ciudad", empleado.Ciudad);
                cmd.Parameters.AddWithValue("@Colonia", empleado.Colonia);
                cmd.Parameters.AddWithValue("@CP", empleado.CP);
                cmd.Parameters.AddWithValue("@EntreCalles", empleado.EntreCalles);
                cmd.Parameters.AddWithValue("@Numero", empleado.Numero);
                cmd.Parameters.AddWithValue("@Asignacion", empleado.Nombre);
                cmd.Parameters.AddWithValue("@CentroCostos", empleado.CentroCosto);
                cmd.Parameters.AddWithValue("@ColaboradorID", empleado.NumEmpleadoE);
                cmd.Parameters.AddWithValue("@Puesto", empleado.Puesto);

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