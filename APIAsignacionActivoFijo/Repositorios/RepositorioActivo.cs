using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioActivo : IRepositorioActivo
    {

        public async Task<List<ActivoVista>> ObtenerActivos(string Empresa, long UbicacionId)
        {
            List<ActivoVista> ListaFinal = new List<ActivoVista>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerActivos(Empresa, UbicacionId);

            foreach (var i in ListaRespuesta)
            {

                
                ListaFinal.Add(new ActivoVista()
                {
                    DiscoDuroPlan = i.DiscoDuro,
                    Empresa = i.Empresa,
                    IdActivo = Convert.ToInt32(i.ActivoID),
                    IdArticulo = Convert.ToInt32(i.ArticuloID),
                    IdDepartamento = i.DepartamentoID,
                    IdUbicacion = Convert.ToInt32(i.UbicacionID),
                    Marca = i.Marca,
                    ModeloVersion = i.Modelo,
                    NombreArticulo = i.Articulo,
                    NombreClasificacion = i.Clasificacion,
                    NumEmpleado = i.Colaborador,                    
                    ProcesadorSim = i.Procesador,
                    RamLinea = i.Ram,
                    SerieImei = i.NumeroSerie,
                    Observaciones = i.Descripcion,
                    FechaAsignacion = i.Fecha

                });
            }



            //if (Empresa == "ECONTACT" && UbicacionId == 1)
            //{
            //    ListaFinal.Add(new ActivoVista()
            //    {
            //        DiscoDuroPlan = "1 TB",
            //        IdActivo = 1,
            //        IdArea = 1,
            //        IdArticulo = 2,
            //        IdClasificacion = 1,
            //        IdDepartamento = 1,
            //        Empresa = "ECONTACT",
            //        IdUbicacion = 1,
            //        Marca = "DELL",
            //        ModeloVersion = "6430u",
            //        ProcesadorSim = "CORE i7",
            //        RamLinea = "8 Gb",
            //        SerieImei = "MX78675556",                    
            //        NombreArticulo = "LAPTOP",
            //        NombreClasificacion = "EQ. COMPUTO",
            //        NumEmpleado = "E000001",
            //        Observaciones = "NINGUNA"

            //    });

            //    ListaFinal.Add(new ActivoVista()
            //    {
            //        DiscoDuroPlan = "POSTPAGO",
            //        IdActivo = 2,
            //        IdArea = 1,
            //        IdArticulo = 3,
            //        IdClasificacion = 2,
            //        IdDepartamento = 2,
            //        Empresa = "ECONTACT",
            //        IdUbicacion = 1,
            //        Marca = "SAMSUNG",
            //        ModeloVersion = "S5830",
            //        ProcesadorSim = "4G LTE",
            //        RamLinea = "SMARTPHONE",
            //        SerieImei = "362587635240982",
            //        NombreArticulo = "CELULAR",
            //        NombreClasificacion = "EQ. COMUNICACION",
            //        NumEmpleado = "E000001",
            //        Observaciones = "NINGUNA"

            //    });

            //}

            return ListaFinal;
        }

        public async Task<KeyValuePair<bool, string>> GuardarActivo(Activo NuevoActivo)
        {
            try
            {

                ACTIVOS_FIJOS.Datos Data =  new ACTIVOS_FIJOS.Datos();
             
                var Respuesta = Data.GuardarActivo(new ACTIVOS_FIJOS.Activo()
                {
                    ArticuloID = NuevoActivo.IdArticulo,
                    DepartamentoID = NuevoActivo.IdDepartamento,
                    DiscoDuro = NuevoActivo.DiscoDuroPlan,
                    Empresa = NuevoActivo.Empresa,
                    Marca = NuevoActivo.Marca,
                    Modelo = NuevoActivo.ModeloVersion,
                    NumeroSerie = NuevoActivo.SerieImei,
                    Procesador = NuevoActivo.ProcesadorSim,
                    Ram = NuevoActivo.RamLinea,
                    UbicacionID = NuevoActivo.IdUbicacion,
                    Descripcion = NuevoActivo.Observaciones
                                 
                    
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
            
        

        public async Task<ActivoVista> ObtenerActivo(int ActivoID)
        {

            ActivoVista ActivoFinal = new ActivoVista();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var RespuestaObj = respuesta.ObtenerActivo(Convert.ToInt64(ActivoID));


            ActivoFinal.DiscoDuroPlan = RespuestaObj.DiscoDuro;
            ActivoFinal.IdActivo = Convert.ToInt32(RespuestaObj.ActivoID);
            //ActivoFinal.IdArea = RespuestaObj.ar
            ActivoFinal.IdArticulo = Convert.ToInt32(RespuestaObj.ArticuloID);
            //ActivoFinal.IdClasificacion = RespuestaObj.id
            ActivoFinal.IdDepartamento = RespuestaObj.DepartamentoID;
            ActivoFinal.Empresa = RespuestaObj.Empresa;
            ActivoFinal.IdUbicacion = Convert.ToInt32(RespuestaObj.UbicacionID);
            ActivoFinal.Marca = RespuestaObj.Marca;
            ActivoFinal.ModeloVersion = RespuestaObj.Modelo;
            ActivoFinal.ProcesadorSim = RespuestaObj.Procesador;
            ActivoFinal.RamLinea = RespuestaObj.Ram;
            ActivoFinal.SerieImei = RespuestaObj.NumeroSerie;
            ActivoFinal.NombreArticulo = RespuestaObj.Articulo;
            ActivoFinal.NombreClasificacion = RespuestaObj.Clasificacion;
            ActivoFinal.NumEmpleado = RespuestaObj.Colaborador;
            ActivoFinal.FechaAsignacion = RespuestaObj.Fecha;

            //if (IdActivo == 1)
            //{
            //    ActivoFinal.DiscoDuroPlan = "1 TB";
            //    ActivoFinal.IdActivo = 1;
            //    ActivoFinal.IdArea = 1;
            //    ActivoFinal.IdArticulo = 2;
            //    ActivoFinal.IdClasificacion = 1;
            //    ActivoFinal.IdDepartamento = 1;
            //    ActivoFinal.Empresa = "ECONTACT";
            //    ActivoFinal.IdUbicacion = 1;
            //    ActivoFinal.Marca = "DELL";
            //    ActivoFinal.ModeloVersion = "6430u";
            //    ActivoFinal.ProcesadorSim = "CORE i7";
            //    ActivoFinal.RamLinea = "8 Gb";
            //    ActivoFinal.SerieImei = "MX78675556";
            //    ActivoFinal.NombreArticulo = "Lap Top";
            //    ActivoFinal.NombreClasificacion = "Computadoras";
            //    ActivoFinal.NumEmpleado = "E000001";
            //}

            return ActivoFinal;
        }
                     
    }              
               
}