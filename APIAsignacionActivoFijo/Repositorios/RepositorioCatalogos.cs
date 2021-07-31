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
    public class RepositorioCatalogos : IRepositorioCatalogos
    {

        SqlConnection conexion = new SqlConnection("Data Source =.; initial catalog = Asignacion_Equipos; User ID = user_asig_eq; Password=asigeq2507;");
        public List<Catalogo> ObtenerEstados()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_ESTADOS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo= new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Estado"].ToString();               

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;

            
        }

        public List<Catalogo> ObtenerMunicipios(int EstadoId)
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_MUNICIPIOS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EstadoId", EstadoId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Estado"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;
        }

        public List<Catalogo> ObtenerAreas()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_AREAS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Articulo"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;
        }

        public List<Catalogo> ObtenerDepartamento(int AreaId)
        {

            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_DEPARTAMENTO]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AreaId", AreaId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Departamento"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;

        }

        public List<Catalogo> ObtenerClasificacion()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_CLASIFICACION]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Clasificacion"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;
        }

        public List<Catalogo> ObtenerArticulo(int ClasificacionId)
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_DEPARTAMENTO]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AreaId", ClasificacionId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Departamento"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;
        }

        public List<Catalogo> ObtenerEstatus()
        {
            List<Catalogo> ListaFinal = new List<Catalogo>();


            string CadSP = "[dbo].[SP_OBTENER_ESTATUS]";
            SqlCommand cmd = new SqlCommand(CadSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Catalogo ElemCatalogo = new Catalogo();

                ElemCatalogo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                ElemCatalogo.Nombre = dt.Rows[i]["Estatus"].ToString();

                ListaFinal.Add(ElemCatalogo);

            }

            return ListaFinal;
        }
            
    }
}