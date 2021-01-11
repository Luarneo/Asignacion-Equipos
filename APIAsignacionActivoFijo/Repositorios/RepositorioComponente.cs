using APIAsignacionActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIAsignacionActivoFijo.Repositorios
{
    public class RepositorioComponente:IRepositorioComponente
    {
        public async Task<KeyValuePair<bool, string>> GuardarComponente(Componente componente)
        {
            try
            {

                ACTIVOS_FIJOS.Datos Data = new ACTIVOS_FIJOS.Datos();

                var Respuesta = Data.GuardarComponente(new ACTIVOS_FIJOS.Componente()
                {
                    ActivoID = Convert.ToInt64(componente.IdActivo),
                    Anotaciones = componente.Anotaciones,
                    ComponenteID = Convert.ToInt64(componente.IdComponente),
                    DiscoDuro = componente.DiscoDuro,
                    Marca = componente.Marca,
                    Modelo = componente.Modelo,
                    NombreComponente = componente.Nombre,
                    Procesador = componente.Procesador,
                    Ram = componente.Ram,
                    Serie = componente.Serie              
                    
                
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

        public async Task<List<Componente>> ObtenerComponentes(int ActivoID)
        {
            List<Componente> ListaFinal = new List<Componente>();

            ACTIVOS_FIJOS.Datos respuesta = new ACTIVOS_FIJOS.Datos();


            var ListaRespuesta = respuesta.ObtenerComponente(Convert.ToInt64(ActivoID));

            foreach (var i in ListaRespuesta)
            {
                ListaFinal.Add(new Componente()
                {
                    IdActivo = Convert.ToInt32(i.ActivoID),
                    IdComponente = Convert.ToInt32(i.ComponenteID),
                    Anotaciones = i.Anotaciones,
                    DiscoDuro = i.DiscoDuro,
                    Marca = i.Marca,
                    Modelo = i.Modelo,
                    Nombre = i.NombreComponente,
                    Procesador = i.Procesador,
                    Ram = i.Ram,
                    Serie = i.Serie

                });
            }


            //if (ActivoId == 1)
            //{
            //    var componente1 = new Componente()
            //    {
            //        IdActivo = 1,
            //        IdComponente = 1,
            //        Anotaciones = "algunas",
            //        DiscoDuro = "1 Tb",
            //        Marca = "DELL",
            //        Modelo = "65HH",
            //        Nombre = "LATITUDE",
            //        Procesador = "CORE I5",
            //        Ram = "4 Gb",
            //        Serie = "876775GYH"
            //    };

            //    var componente2 = new Componente()
            //    {
            //        IdActivo = 1,
            //        IdComponente = 2,
            //        Anotaciones = "algunas",
            //        DiscoDuro = "2 Tb",
            //        Marca = "LENOVO",
            //        Modelo = "YUTU5",
            //        Nombre = "INSIDER 567",
            //        Procesador = "CORE I7",
            //        Ram = "8 Gb",
            //        Serie = "UYIUY65554"
            //    };

            //    ListaFinal.Add(componente1);
            //    ListaFinal.Add(componente2);
            //}

            return ListaFinal;
        }
    }
}