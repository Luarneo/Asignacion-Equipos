using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioUbicacion : IRepositorioUbicacion
    {

        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");

        public KeyValuePair<bool, string> ActualizarUbicaciones(int UbicacionId, bool Estatus)
        {
            try
            {

                string CadSP = "dbo.[SP_ACTUALIZAR_UBICACIONES]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UbicacionId", UbicacionId);
                cmd.Parameters.AddWithValue("@Estatus", Estatus);
               

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

        public KeyValuePair<bool, string> GuardarUbicacion(Ubicacion NuevaUbicacion)
        {
            try
            {

                string CadSP = "dbo.[SP_GUARDAR_UBICACION]";

                SqlCommand cmd = new SqlCommand(CadSP, conexion);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdManicipio", NuevaUbicacion.IdMunicipio);
                cmd.Parameters.AddWithValue("@Sucursal", NuevaUbicacion.Nombre);
               
                
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

        public List<Ubicacion> ObtenerUbicaciones()
        {


            List<Ubicacion> ListaFinal = new List<Ubicacion>();


            string CadSP = "[dbo].[SP_OBTENER_UBICACIONES]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ubicacion ElemUbicacion = new Ubicacion();

                ElemUbicacion.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemUbicacion.IdMunicipio = Convert.ToInt32(dt.Rows[i]["IdMunicipio"]); ;
                ElemUbicacion.Nombre = dt.Rows[i]["Sucursal"].ToString();
                ElemUbicacion.Estatus = Convert.ToBoolean(dt.Rows[i]["Visible"]);                

                ListaFinal.Add(ElemUbicacion);

            }

            return ListaFinal;
        }

        public List<Ubicacion> ObtenerUbicacionesActivas()
        {

            List<Ubicacion> ListaFinal = new List<Ubicacion>();


            string CadSP = "[dbo].[SP_OBTENER_UBICACIONES_ACTIVAS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ubicacion ElemUbicacion = new Ubicacion();

                ElemUbicacion.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemUbicacion.IdMunicipio = Convert.ToInt32(dt.Rows[i]["IdMunicipio"]); ;
                ElemUbicacion.Nombre = dt.Rows[i]["Sucursal"].ToString();
                ElemUbicacion.Estatus = Convert.ToBoolean(dt.Rows[i]["Visible"]);

                ListaFinal.Add(ElemUbicacion);

            }

            return ListaFinal;
        }
    }
}