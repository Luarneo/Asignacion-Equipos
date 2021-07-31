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
    public class RepositorioActivo : IRepositorioActivo
    {

        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");

        public List<ActivoVista> ObtenerActivos(string Empresa, long UbicacionId)
        {
            

            List<ActivoVista> ListaFinal = new List<ActivoVista>();
            
            
            string CadSP = "[dbo].[SP_OBTENER_ACTIVOS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Empresa", Empresa);
            cmd.Parameters.AddWithValue("@IdUbicacion", UbicacionId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActivoVista ElemActivo = new ActivoVista();

                ElemActivo.IdActivo = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemActivo.Empresa = dt.Rows[i]["Empresa"].ToString();
                ElemActivo.IdDepartamento = Convert.ToInt32(dt.Rows[i]["IdDepartamento"]);
                ElemActivo.IdArticulo = Convert.ToInt32(dt.Rows[i]["IdArticulo"]);
                ElemActivo.IdUbicacion = Convert.ToInt32(dt.Rows[i]["IdUbicacion"]);
                ElemActivo.Marca = dt.Rows[i]["Marca"].ToString();
                ElemActivo.ModeloVersion = dt.Rows[i]["Modelo"].ToString();
                ElemActivo.ProcesadorSim = dt.Rows[i]["Procesador"].ToString();
                ElemActivo.DiscoDuroPlan = dt.Rows[i]["DiscoDuro"].ToString();
                ElemActivo.RamLinea = dt.Rows[i]["Ram"].ToString();
                ElemActivo.SerieImei = dt.Rows[i]["NumeroSerie"].ToString();
                ElemActivo.Observaciones = dt.Rows[i]["Descripcion"].ToString();

                ListaFinal.Add(ElemActivo);

            }

            return ListaFinal;
        }

        public KeyValuePair<bool, string> GuardarActivo(Activo NuevoActivo)
        {
            try
            {

                string CadSP = "dbo.[SP_GUARDAR_ACTIVO]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Empresa", NuevoActivo.Empresa);
                cmd.Parameters.AddWithValue("@IdDepartamento", NuevoActivo.IdDepartamento);
                cmd.Parameters.AddWithValue("@IdArticulo", NuevoActivo.IdArticulo);
                cmd.Parameters.AddWithValue("@IdUbicacion", NuevoActivo.IdUbicacion);
                cmd.Parameters.AddWithValue("@Marca", NuevoActivo.Marca);
                cmd.Parameters.AddWithValue("@Modelo", NuevoActivo.ModeloVersion);
                cmd.Parameters.AddWithValue("@Procesador", NuevoActivo.ProcesadorSim);
                cmd.Parameters.AddWithValue("@DiscoDuro", NuevoActivo.DiscoDuroPlan);
                cmd.Parameters.AddWithValue("@Ram", NuevoActivo.RamLinea);
                cmd.Parameters.AddWithValue("@NumeroSerie", NuevoActivo.SerieImei);
                cmd.Parameters.AddWithValue("@Descripcion", NuevoActivo.Observaciones);

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
            
        

        public ActivoVista ObtenerActivo(int ActivoID)
        {
            ActivoVista ActivoFinal = new ActivoVista();
            string CadSP = "[dbo].[SP_OBTENER_ACTIVO]";

            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivoId", ActivoID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            ActivoVista ElemActivo = new ActivoVista();

            ElemActivo.IdActivo = Convert.ToInt32(dt.Rows[0]["Id"]);
            ElemActivo.Empresa = dt.Rows[0]["Empresa"].ToString();
            ElemActivo.IdDepartamento = Convert.ToInt32(dt.Rows[0]["IdDepartamento"]);
            ElemActivo.IdArticulo= Convert.ToInt32(dt.Rows[0]["IdArticulo"]);
            ElemActivo.IdUbicacion = Convert.ToInt32(dt.Rows[0]["IdUbicacion"]);
            ElemActivo.Marca = dt.Rows[0]["Marca"].ToString();
            ElemActivo.ModeloVersion = dt.Rows[0]["Modelo"].ToString();
            ElemActivo.ProcesadorSim = dt.Rows[0]["Procesador"].ToString();
            ElemActivo.DiscoDuroPlan = dt.Rows[0]["DiscoDuro"].ToString();
            ElemActivo.RamLinea = dt.Rows[0]["Ram"].ToString();
            ElemActivo.SerieImei = dt.Rows[0]["NumeroSerie"].ToString();
            ElemActivo.Observaciones = dt.Rows[0]["Descripcion"].ToString();
            
            return ActivoFinal;
        }
                     
    }              
               
}