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
    public class RepositorioComponente:IRepositorioComponente
    {

        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");
        public KeyValuePair<bool, string> GuardarComponente(Componente componente)
        {
            try
            {

                string CadSP = "dbo.[SP_GUARDAR_COMPONENTE]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreComponente", componente.Nombre);
                cmd.Parameters.AddWithValue("@ActivoId", componente.IdActivo);
                cmd.Parameters.AddWithValue("@Marca", componente.Marca);
                cmd.Parameters.AddWithValue("@Modelo", componente.Modelo);
                cmd.Parameters.AddWithValue("@Serie", componente.Serie);
                cmd.Parameters.AddWithValue("@Procesador", componente.Procesador);
                cmd.Parameters.AddWithValue("@DiscoDuro", componente.DiscoDuro);
                cmd.Parameters.AddWithValue("@Ram", componente.Ram);
                cmd.Parameters.AddWithValue("@Anotaciones", componente.Anotaciones);
      
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

        public List<Componente> ObtenerComponentes(int ActivoID)
        {
            List<Componente> ListaFinal = new List<Componente>();


            string CadSP = "[dbo].[SP_OBTENER_COMPONENTES]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivoId", ActivoID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Componente ElemActivo = new Componente();

                ElemActivo.IdComponente = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemActivo.Nombre = dt.Rows[i]["Componente"].ToString();
                ElemActivo.IdActivo = Convert.ToInt32(dt.Rows[i]["ActivoId"]);
                ElemActivo.Marca = dt.Rows[i]["Marca"].ToString();
                ElemActivo.Modelo = dt.Rows[i]["Serie"].ToString();
                ElemActivo.Procesador = dt.Rows[i]["Procesador"].ToString();
                ElemActivo.DiscoDuro = dt.Rows[i]["DiscoDuro"].ToString();
                ElemActivo.Ram = dt.Rows[i]["Ram"].ToString();
                ElemActivo.Anotaciones = dt.Rows[i]["Anotaciones"].ToString();





                ListaFinal.Add(ElemActivo);
            }
            return ListaFinal;
        }
    }
}