using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioUbicacion : IRepositorioUbicacion
    {

        

        public async Task<KeyValuePair<bool, string>> ActualizarUbicaciones(int UbicacionId, bool Estatus)
        {
            try
            {

                ACTIVOS_FIJOS.Datos Data = new ACTIVOS_FIJOS.Datos();

                var Respuesta = Data.EditarUbicacion(UbicacionId, Estatus);
                
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

        public async Task<KeyValuePair<bool, string>> GuardarUbicacion(Ubicacion NuevaUbicacion)
        {
            try
            {

                ACTIVOS_FIJOS.Datos Data = new ACTIVOS_FIJOS.Datos();

                var Respuesta = Data.GuardarUbicacion(NuevaUbicacion.IdMunicipio, NuevaUbicacion.Nombre);
                
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

        public async Task<List<Ubicacion>> ObtenerUbicaciones()
        {
            

            List<Ubicacion> ListaFinal = new List<Ubicacion>();         

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerUbicacion();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Ubicacion() 
                {
                    Id = Convert.ToInt32(i.UbicacionID), 
                    Nombre = i.Sucursal, 
                    Estatus = i.Visible, 
                    NombreEstado = i.Estado, 
                    NombreMunicipio=i.Municipio, 
                    IdMunicipio = Convert.ToInt32(i.MunicipioID) 
                });
            }




            //ListaFinal.Add(new Ubicacion() { Id = 1, Nombre = "E.GUADALUPE", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "SAN ANDRES CHOLULA" });
            //ListaFinal.Add(new Ubicacion() { Id = 2, Nombre = "E.PIRAMIDE", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "SAN ANDRES CHOLULA" });
            //ListaFinal.Add(new Ubicacion() { Id = 3, Nombre = "E.REFORMA", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "PUEBLA" });
            //ListaFinal.Add(new Ubicacion() { Id = 4, Nombre = "P.SUR", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "PUEBLA" });
            //ListaFinal.Add(new Ubicacion() { Id = 5, Nombre = "P.AMERICA", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "PUEBLA" });

            return ListaFinal;
        }

        public async Task<List<Ubicacion>> ObtenerUbicacionesActivas()
        {

            List<Ubicacion> ListaFinal = new List<Ubicacion>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();

            var ListaRespuesta = respuesta.ObtenerUbicacionesActivas();

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Ubicacion()
                {
                    Id = Convert.ToInt32(i.UbicacionID),
                    Nombre = i.Sucursal,
                    Estatus = i.Visible,
                    NombreEstado = i.Estado,
                    NombreMunicipio = i.Municipio,
                    IdMunicipio = Convert.ToInt32(i.MunicipioID)
                });
            }



            //List<Ubicacion> ListaFinal = new List<Ubicacion>();
            //ListaFinal.Add(new Ubicacion() { Id = 1, Nombre = "E.GUADALUPE", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "SAN ANDRES CHOLULA" });
            //ListaFinal.Add(new Ubicacion() { Id = 2, Nombre = "E.PIRAMIDE", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "SAN ANDRES CHOLULA" });
            //ListaFinal.Add(new Ubicacion() { Id = 3, Nombre = "E.REFORMA", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "PUEBLA" });           
            //ListaFinal.Add(new Ubicacion() { Id = 5, Nombre = "P.AMERICA", Estatus = true, IdMunicipio = 1, NombreEstado = "PUEBLA", NombreMunicipio = "PUEBLA" });

            return ListaFinal;
        }
    }
}