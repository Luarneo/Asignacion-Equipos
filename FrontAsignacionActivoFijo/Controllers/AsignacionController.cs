using FrontAsignacionActivoFijo.Consumidor;
using FrontAsignacionActivoFijo.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;



namespace FrontAsignacionActivoFijo.Controllers
{
    public class AsignacionController : Controller
    {


        private IConsumidorActivo _ServicioActivo;
        private IConsumidorCatalogos _ServicioCatalogos;
        private IConsuidorUbicaciones _ServicioUbicaciones;
        private IConsumidorEmpleado _ServicioEmpleado;

        public AsignacionController() : this(new ConsumidorActivo(), new ConsumidorCatalogos(), new ConsumidorUbicaciones(), new ConsumidorEmpleado()) { }

        public AsignacionController(IConsumidorActivo servicio, IConsumidorCatalogos servicio2, IConsuidorUbicaciones servicio3, IConsumidorEmpleado servicio4)
        {
            this._ServicioActivo = servicio;
            this._ServicioCatalogos = servicio2;
            this._ServicioUbicaciones = servicio3;
            this._ServicioEmpleado = servicio4;
        }


        // GET: Asignacion
        [Authorize]
        public async Task<ActionResult> Index()
        {

            List<CatalogosViewModel> ListaEmpresas = new List<CatalogosViewModel>();
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 1, Nombre = "ECONTACT" });
            ListaEmpresas.Add(new CatalogosViewModel() { Id = 2, Nombre = "SERVINEXT" });

            ViewBag.ListaEmpresas = ListaEmpresas;
            ViewBag.ListaUbicaciones = await _ServicioUbicaciones.ObtenerUbicaciones(2);
            

            return View(new List<ActivoViewModel>());
        }

        public async Task<JsonResult> MostrarActivos(string Empresa, long UbicacionId)
        {          

            var contenido = await _ServicioActivo.ObtenerActivosEmpresaUbicac(Empresa, UbicacionId);
            return Json(contenido, JsonRequestBehavior.AllowGet);
        }

        public async Task<PartialViewResult> AsignarActivo(string Serie, int ActivoId, string Articulo, string Marca, string Modelo, string Procesador, string Disco, string Ram, string Ubicacion)
        {
            ViewBag.SerieActivo = Serie;
            ViewBag.IdDelActivo = ActivoId;
            ViewBag.ArticuloS = Articulo;
            ViewBag.MarcaS = Marca;
            ViewBag.ModeloS = Modelo;
            ViewBag.ProcesadorS = Procesador;                              
            ViewBag.DiscoS = Disco;
            ViewBag.RamS = Ram;
            ViewBag.UbicacionS = Ubicacion;
            //ViewBag.FechaAsignacion = DateTime.Now.ToString("dd/MM/yyyy");

            ViewBag.ListaEstatus = await _ServicioCatalogos.ObtenerCatalogos(4);

            return PartialView("_NuevaAsignacionEmpleado", new AsignacionEmpleadoViewModel()
            {
                ArticuloA = Articulo
            }); 

        }



        public async Task<ActionResult> GenerarResponsivaDescagable(int IdActivo, string Ubicacion)
        {

            var DatosActivo = await _ServicioActivo.ObtenerActivoPorId(IdActivo);
            var Datosempleado = await _ServicioEmpleado.ObtenerEmpleado(DatosActivo.NumEmpleado);


            if (Datosempleado.NumEmpleadoE != null)
            {
                
                var Fecha = DatosActivo.FechaAsignacion.ToString().Substring(0, 10);           

                

                GenerarReponsiva(Datosempleado.Nombre, Datosempleado.Puesto, Datosempleado.NumEmpleadoE, Datosempleado.CentroCosto, DatosActivo.Marca,
               DatosActivo.ModeloVersion, DatosActivo.SerieImei, DatosActivo.ProcesadorSim, DatosActivo.DiscoDuroPlan,
               DatosActivo.RamLinea, Datosempleado.Calle, Datosempleado.Numero, Datosempleado.Colonia, Datosempleado.CP, Datosempleado.CP,
               Datosempleado.EntreCalles, DatosActivo.NombreArticulo, Fecha, Ubicacion);

                TempData["Mensaje2"] = new KeyValuePair<string, string>("success", "Descarga exitosa !!!");

            }
            else
            {
                TempData["Mensaje2"] = new KeyValuePair<string, string>("danger", "El activo aun no se asigna a un colaborador");

            }
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> BuscarEmpleado(string NumEmpleado)
        {
            return Json(await _ServicioEmpleado.ObtenerEmpleado(NumEmpleado), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AsignarActivo(AsignacionEmpleadoViewModel NuevaAsignacionEmpleado)
        {
                      

            try
            {
                if (ModelState.IsValid)
                {

                    AsignacionViewModel NuevaAsignacion = new AsignacionViewModel()
                    {
                        FechaAsignacion = NuevaAsignacionEmpleado.FechaAsignacion,
                        IdActivo = NuevaAsignacionEmpleado.IdActivo,
                        IdEstatus = NuevaAsignacionEmpleado.IdEstatus,
                        NumEmpleado = NuevaAsignacionEmpleado.NumEmpleadoA
                    };

                    var ResultadoAsignacion = await _ServicioActivo.GuardarAsignacion(NuevaAsignacion);

                    if (ResultadoAsignacion.Value.Contains("Operacion Exitosa"))
                    {
                        TempData["Mensaje"] = new KeyValuePair<string, string>("success", "El activo se ha actualizado correctamente !!!");
                      
                    }
                    else
                    {
                        TempData["Mensaje"] = new KeyValuePair<string, string>("danger", "Error al asignar activo");
                    }
                                       

                    if (NuevaAsignacionEmpleado.ActualizacionEmpleado == true)
                    {
                        EmpleadoViewModel EmpleadoActualizar = new EmpleadoViewModel()
                        {
                            Calle = NuevaAsignacionEmpleado.Calle,
                            CentroCosto = NuevaAsignacionEmpleado.CentroCosto,
                            Ciudad = NuevaAsignacionEmpleado.Ciudad,
                            Colonia = NuevaAsignacionEmpleado.Colonia,
                            CP = NuevaAsignacionEmpleado.CP,
                            EntreCalles = NuevaAsignacionEmpleado.EntreCalles,
                            Nombre = NuevaAsignacionEmpleado.Nombre,
                            Numero = NuevaAsignacionEmpleado.Numero,
                            Puesto = NuevaAsignacionEmpleado.Puesto,
                            NumEmpleadoE = NuevaAsignacionEmpleado.NumEmpleadoE
                        };

                        var ResultadoEmpleado = await _ServicioEmpleado.ActualizarEmpleado(EmpleadoActualizar);

                        if (ResultadoAsignacion.Value.Contains("Operacion Exitosa"))
                        {
                            TempData["Mensaje2"] = new KeyValuePair<string, string>("success", "Los datos del colaborador se actualizaron correctamente !!!");
                            
                        }
                        else
                        {
                            TempData["Mensaje2"] = new KeyValuePair<string, string>("danger", "Error al actualizar los datos del colaborador");
                        }

                    }                                      
                   
                }
            }
            catch (Exception ex)
            {

                TempData["Mensaje"] = new KeyValuePair<string, string>("danger", "Error: " + ex.Message);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }



     
        public void GenerarReponsiva(
            string Nombref, 
            string Puestof, 
            string NumEmpf, 
            string Areaf, 
            string Marcaf, 
            string Modelof,
            string Serief,
            string Procesadorf,
            string Discof,
            string Ramf,
            string Callef,
            string Numf,
            string Coloniaf,
            string CPf,
            string Ciudadf,
            string EntreCallesf,
            string Articulof,
            string Fechaf,
            string Ubicacionf
            )
        {

            //var filex = new FileInfo(@"C:\Users\e000796\Documents\Proyectos DS\Activo Fijo\Resposiva\Responsiva.xlsx");

            var filex = new FileInfo(ConfigurationManager.AppSettings["PathResponsiva"].ToString());

            using (ExcelPackage excel = new ExcelPackage(filex))
            { 
                var sheet = excel.Workbook.Worksheets[1];
                /*Selecciono el rango de celdas a modificar, los combino y meto el texto centrado*/

                //Nombre
                var cell1 = sheet.Cells["C6"];
                //cell1.Merge = true;
                //cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                cell1.Value = Nombref;

                //Puesto
                var cell2 = sheet.Cells["C7"];                       
                cell2.Value = Puestof;

                //Lugar
                var cell3 = sheet.Cells["C8"];
                cell3.Value = Ubicacionf;

                //Numero empleado
                var cell4 = sheet.Cells["G6"];
                cell4.Value = NumEmpf;

                //Area, Proyecto
                var cell5 = sheet.Cells["G7"];
                cell5.Value = Areaf;

                //Fecha
                var cell20 = sheet.Cells["G8"];
                cell20.Value = Fechaf;

                /////// Contenido  /////////////////////////////////////

                var validador = false;

                /// LapTop, Mini Laptop
                if (Articulof == "LAPTOP" || Articulof == "MINI LAPTOP")
                {

                    //Marca
                    var cell6 = sheet.Cells["C17"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D17"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E17"];
                    cell8.Value = Serief;

                    //Procesador
                    var cell9 = sheet.Cells["F17"];
                    cell9.Value = Procesadorf;

                    //Disco Duro
                    var cell10 = sheet.Cells["G17"];
                    cell10.Value = Discof;

                    //RAM
                    var cell11 = sheet.Cells["H17"];
                    cell11.Value = Ramf;

                    validador = true;


                }

                /// ALL IN ONE, COMPUTADORA, DEKSTOP  
                if (Articulof == "ALL IN ONE" || Articulof == "COMPUTADORA" || Articulof == "DEKSTOP" || Articulof == "DESKTOP")
                {

                    //Marca
                    var cell6 = sheet.Cells["C18"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D18"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E18"];
                    cell8.Value = Serief;

                    //Procesador
                    var cell9 = sheet.Cells["F18"];
                    cell9.Value = Procesadorf;

                    //Disco Duro
                    var cell10 = sheet.Cells["G18"];
                    cell10.Value = Discof;

                    //RAM
                    var cell11 = sheet.Cells["H18"];
                    cell11.Value = Ramf;

                    validador = true;

                }

                /// Celular
                if (Articulof == "CELULAR" )
                {

                    //Marca
                    var cell6 = sheet.Cells["C12"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D12"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E12"];
                    cell8.Value = Serief;

                    //Numero
                    var cell9 = sheet.Cells["G12"];
                    cell9.Value = Ramf;

                    validador = true;

                }

                /// MONITOR
                if (Articulof == "MONITOR")
                {

                    //Marca
                    var cell6 = sheet.Cells["C21"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D21"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E21"];
                    cell8.Value = Serief;

                    validador = true;

                }

                /// CAMARA FOTOGRAFICA
                if (Articulof == "CAMARA FOTOGRAFICA")
                {

                    //Marca
                    var cell6 = sheet.Cells["C23"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D23"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E23"];
                    cell8.Value = Serief;

                    validador = true;

                }

                /// PROYECTOR
                if (Articulof == "PROYECTOR")
                {

                    //Marca
                    var cell6 = sheet.Cells["C24"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D24"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E24"];
                    cell8.Value = Serief;

                    validador = true;

                }

                /// IMPRESORA, MULTIFUNCIONAL 
                if (Articulof == "IMPRESORA" || Articulof == "MULTIFUNCIONAL")
                {

                    //Marca
                    var cell6 = sheet.Cells["C25"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D25"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E25"];
                    cell8.Value = Serief;

                    validador = true;

                }

                /// MOTOCICLETA
                if (Articulof == "MOTOCICLETA")
                {

                    //Marca
                    var cell6 = sheet.Cells["C28"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D28"];
                    cell7.Value = Modelof;

                    validador = true;



                }

                /// AUTOMOVIL
                if (Articulof == "AUTOMOVIL")
                {

                    //Marca
                    var cell6 = sheet.Cells["C29"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D29"];
                    cell7.Value = Modelof;

                    validador = true;


                }

                /// DISCO DURO
                if (Articulof == "DISCO DURO")
                {

                    //Marca
                    var cell6 = sheet.Cells["G21"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["H21"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["I21"];
                    cell8.Value = Serief;

                    validador = true;

                }

                /// MEMORIA USB
                if (Articulof == "MEMORIA USB")
                {

                    //Marca
                    var cell6 = sheet.Cells["G22"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["H22"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["I22"];
                    cell8.Value = Serief;

                    validador = true;

                }

                if (validador == false)
                {
                    //Marca
                    var cell6 = sheet.Cells["C32"];
                    cell6.Value = Marcaf;

                    //Modelo
                    var cell7 = sheet.Cells["D32"];
                    cell7.Value = Modelof;

                    //Serie
                    var cell8 = sheet.Cells["E32"];
                    cell8.Value = Serief;

                    //Descripcion
                    var cell9 = sheet.Cells["F32"];
                    cell9.Value = Articulof;

                }



                /////// Datos de colaborador (pie de pagina)  /////////////////////////////////////

                //Calle
                var cell12 = sheet.Cells["C58"];
                cell12.Value = Callef;

                //Numero de casa
                var cell13 = sheet.Cells["E58"];
                cell13.Value = Numf;

                //Colonia
                var cell14 = sheet.Cells["G58"];
                cell14.Value = Coloniaf;

                //CP
                var cell15 = sheet.Cells["C61"];
                cell15.Value = CPf;

                //Ciudad
                var cell16 = sheet.Cells["E61"];
                cell16.Value = Ciudadf;

                //Entre calles
                var cell17 = sheet.Cells["G61"];
                cell17.Value = EntreCallesf;

                /*Guardo el cambio*/
                //excel.Save();


                //// Enviar al navegador


                byte[] bin = excel.GetAsByteArray();
               
                Response.ClearHeaders();
                Response.Clear();
                Response.Buffer = true;           
                Response.ContentType = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";                
                Response.AddHeader("content-length", bin.Length.ToString());                
                Response.AddHeader("content-disposition", "attachment; filename=\"Responsiva.xlsx\"");              
                Response.OutputStream.Write(bin, 0, bin.Length);                
                Response.Flush();


                Nombref = "";
                Puestof = "";
            }


        }

    }
}
