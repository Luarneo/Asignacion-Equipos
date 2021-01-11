using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIAsignacionActivoFijo.Controllers;
using APIAsignacionActivoFijo.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using APIAsignacionActivoFijo.Repositorios;

namespace PruebasAsignacionActivoFijo
{
    [TestClass]
    public class PruebasWebAPI
    {

        private UbicacionController _UbicacionController;
        private CatalogosController _CatalogosController;
        private ArticuloController _ArticuloController;
        private EmpleadoController _EmpleadoController;
        private ComponenteController _ComponenteController;


        [TestInitialize]
        public void Inicializador()
        {
            
            _UbicacionController = new UbicacionController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _CatalogosController = new CatalogosController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            IRepositorioActivo RepoActivo = new RepositorioActivo();
            IRepositorioAsignacion RepoAsignacion = new RepositorioAsignacion();

            _ArticuloController = new ArticuloController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _EmpleadoController = new EmpleadoController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            _ComponenteController = new ComponenteController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public async Task ContarListaUbicacionesTodas()
        {
            HttpResponseMessage respuesta = await _UbicacionController.GetUbicacion(1);
            List<Ubicacion> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Ubicacion>>();
            Assert.AreEqual(5, respuestacontenido.Count);

        }

        [TestMethod]
        public async Task ContarListaUbicacionesActivas()
        {
            HttpResponseMessage respuesta = await _UbicacionController.GetUbicacion(2);
            List<Ubicacion> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Ubicacion>>();
            Assert.AreEqual(4, respuestacontenido.Count);

        }

        [TestMethod]
        public async Task  ObtenerEstados()
        {

            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerCatalogos(1);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();          
            Assert.AreEqual("TLAXCALA", respuestacontenido[1].Nombre);

        }

        [TestMethod]
        public async Task ObtenerDepartamentos()
        {

            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerDepartamentos(1);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();
            Assert.AreEqual("TESORERIA", respuestacontenido[2].Nombre);

        }

        [TestMethod]
        public async Task ObtenerArticulos()
        {

            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerArticulos(1);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();
            Assert.AreEqual("ALL IN ONE", respuestacontenido[1].Nombre);

        }

        [TestMethod]
        public async Task ObtenerMunicipiosEstadoId1()
        {
            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerMunicipios(1);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();
            Assert.AreEqual(3, respuestacontenido.Count);
        }

        [TestMethod]
        public async Task GuardarUbicacion()
        {

            Ubicacion NuevaUbicacion = new Ubicacion()
            {
                Id = 1,
                Nombre = "ubicacion ejemplo",
                Estatus = true,
                IdMunicipio = 1

            };

            HttpResponseMessage respuesta = await _UbicacionController.PostUbicacion(NuevaUbicacion);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);

        }


        [TestMethod]
        public async Task CambiarEstatusUbicacion()
        {
           

            HttpResponseMessage respuesta = await _UbicacionController.PutUbicacion(1, false);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);
        }



        [TestMethod]
        public async Task ObtenerAreaAdminFinanzas()
        {
            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerCatalogos(2);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();
            Assert.AreEqual("ADMINISTRACION Y FINANZAS", respuestacontenido[0].Nombre);

        }


        [TestMethod]
        public async Task ObtenerArticulosClasif1()
        {
            HttpResponseMessage respuesta = await _CatalogosController.GetObtenerArticulos(1);
            List<Catalogo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Catalogo>>();
            Assert.AreEqual(2, respuestacontenido[1].Id);

        }

        [TestMethod]
        public async Task ObtenerActivoFiltradoPorEmpresaUbicacion()
        {
            HttpResponseMessage respuesta = await _ArticuloController.GetActivo("ECONTACT", 1);
            List<Activo> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Activo>>();
            Assert.AreEqual(2, respuestacontenido[1].IdActivo);

        }

        [TestMethod]
        public async Task GuardarActivo()
        {

            Activo NuevoActivo = new Activo()
            {

                Empresa = "ECONTACT",
                IdArea = 2,
                IdDepartamento = 1,
                IdUbicacion = 1,
                IdClasificacion = 2,
                IdArticulo = 2,
                Marca = "Compaq",
                ModeloVersion = "A530",
                ProcesadorSim = "Core i7",
                DiscoDuroPlan = "1Tb",
                RamLinea = "8 Gb",
                SerieImei = "65HGY8978",
                Observaciones = "XXXXXXXX"           
            

            };

            HttpResponseMessage respuesta = await _ArticuloController.PostActivo(NuevoActivo);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);

        }

        [TestMethod]
        public async Task ObtenerActivoPorId()
        {
            HttpResponseMessage respuesta = await _ArticuloController.GetActivo(1);
            Activo respuestacontenido = await respuesta.Content.ReadAsAsync<Activo>();
            Assert.AreEqual("6430u", respuestacontenido.ModeloVersion);

        }

        [TestMethod]
        public async Task GuardarAsignacion()
        {
            Asignacion NuevaAsignacion= new Asignacion()
            {

                IdActivo = 1,
                IdEstatus = 2,
                FechaAsignacion = new System.DateTime(2020, 01, 10, 16, 47, 45),
                NumEmpleado = "E000796"
            
            };

            HttpResponseMessage respuesta = await _ArticuloController.PostAsignacion(NuevaAsignacion);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);

        }

        [TestMethod]
        public async Task ActualizarEmpleado()
        {
            Empleado NuevoEmpleado = new Empleado()
            {
                NumEmpleadoE = "E000796",
                Nombre = "Juan Carlos Perez Gonzalez",
                Puesto = "Supervisor",
                CentroCosto = "Gentera",
                Calle = "Av. Insurgentes",
                Numero = "45",
                Ciudad = "Puebla",
                Colonia = "centro",
                CP = "90987",
                EntreCalles = "Pino Suarez y 16 de septiembre"        

            };

            HttpResponseMessage respuesta = await _EmpleadoController.PutEmpleado(NuevoEmpleado);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();
            
            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);
            
        }

        [TestMethod]
        public async Task ObtenerEmpleado()
        {
            HttpResponseMessage respuesta = await _EmpleadoController.GetEmpleado("E000002");
            Empleado respuestacontenido = await respuesta.Content.ReadAsAsync<Empleado>();
            Assert.AreEqual("LOLA LOPEZ", respuestacontenido.Nombre);
        }

        [TestMethod]
        public async Task GuardarComponente()
        {
            Componente NuevoComponente = new Componente()
            {
                Nombre = "MEMORIA RAM",
                Marca = "DELL",
                Modelo = "E6430 MEMORIA",
                Serie = "200-Pin DDR2 667 SO-DIMM",
                Procesador = "CORE i7",
                DiscoDuro = "500 Gb",
                Ram = "8Gb",
                Anotaciones = "xxxxxx"
            };

            HttpResponseMessage respuesta = await _ComponenteController.PostComponente(NuevoComponente);
            KeyValuePair<bool, string> respuestaContenido = await respuesta.Content.ReadAsAsync<KeyValuePair<bool, string>>();

            Assert.IsTrue(respuesta.IsSuccessStatusCode);
            Assert.IsTrue(respuestaContenido.Key);

        }

        [TestMethod]
        public async Task ObtenerComponentePorId()
        {

            HttpResponseMessage respuesta = await _ComponenteController.GetComponente(1);
            List<Componente> respuestacontenido = await respuesta.Content.ReadAsAsync<List<Componente>>();
            Assert.AreEqual("LATITUDE", respuestacontenido[0].Nombre);

        }
    }
}
