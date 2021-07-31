using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontAsignacionActivoFijo.Consumidor;
using FrontAsignacionActivoFijo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasAsignacionActivoFijo
{
    [TestClass]
    public class PruebasConsumidor
    {

        private IConsuidorUbicaciones _ServicioUbicaciones;
        private IConsumidorCatalogos _ServicioCatalogos;
        private IConsumidorActivo _ServicioActivo;
        private IConsumidorEmpleado _ServicioEmpleado;
        private IConsumidorComponentes _ServicioComponentes;

        [TestInitialize()]
        public void Inicializar()
        {
            _ServicioUbicaciones = new ConsumidorUbicaciones();
            _ServicioCatalogos = new ConsumidorCatalogos();
            _ServicioActivo = new ConsumidorActivo();
            _ServicioEmpleado = new ConsumidorEmpleado();
            _ServicioComponentes = new ConsumidorComponentes();
        }

        [TestMethod]
        public async Task ObtenerUbicacionesTodas()
        {
            var resultado = await _ServicioUbicaciones.ObtenerUbicaciones(1) as IEnumerable<UbicacionesViewModel>;
            Assert.AreEqual(4, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerUbicacionesActivas()
        {
            var resultado = await _ServicioUbicaciones.ObtenerUbicaciones(2) as IEnumerable<UbicacionesViewModel>;
            Assert.AreEqual(3, resultado.Count());
        }


        [TestMethod]
        public async Task GuardarUbicacion()
        {
            var resultado = await _ServicioUbicaciones.GuardarUbicacion(new UbicacionesViewModel
            {
                Estatus = true,
                IdMunicipio = 1,
                 Nombre = "REFORMA II"                   
            });                                 

            Assert.AreEqual(true, resultado.Value.Contains("Exitosa"));
        }

        [TestMethod]
        public async Task ObtenerEstados()
        {
            var resultado = await _ServicioCatalogos.ObtenerCatalogos(1) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(32, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerMunicipiosEstadoId6()
        {
            var resultado = await _ServicioCatalogos.ObtenerMunicipios(1) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(11, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerAreas()
        {
            var resultado = await _ServicioCatalogos.ObtenerCatalogos(2) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(10, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerClasificaciones()
        {
            var resultado = await _ServicioCatalogos.ObtenerCatalogos(3) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(10, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerDepartamentosArea1()
        {
            var resultado = await _ServicioCatalogos.ObtenerDepartamentos(1) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(6, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerArticulosClasif1()
        {
            var resultado = await _ServicioCatalogos.ObtenerArticulos(1) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(24, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerArticulosClasif4()
        {
            var resultado = await _ServicioCatalogos.ObtenerArticulos(4) as IEnumerable<CatalogosViewModel>;
            Assert.AreEqual(53, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerActivosPorEmpresaUbicacion()
        {
            var resultado = await _ServicioActivo.ObtenerActivosEmpresaUbicac("SERVICIOS INTEGRALES S.A",2) as IEnumerable<ActivoViewModel>;
            Assert.AreEqual(2, resultado.Count());
        }

        [TestMethod]
        public async Task ObtenerActivoPorId()
        {
            var resultado = await _ServicioActivo.ObtenerActivoPorId(1);
            Assert.AreEqual("C56", resultado.ModeloVersion);
        }

        [TestMethod]
        public async Task GuardarActivo()
        {
            var resultado = await _ServicioActivo.GuardarActivo(new ActivoViewModel
            {
                Empresa = "SERVICIOS INTERALES S.A",
                IdArea = 2,
                IdDepartamento = 1,
                IdUbicacion = 2,
                IdClasificacion = 2,
                IdArticulo = 2,
                Marca = "Compaq",
                ModeloVersion = "A530",
                ProcesadorSim = "Core i7",
                DiscoDuroPlan = "1Tb",
                RamLinea = "8 Gb",
                SerieImei = "65HGY8978",
                Obervaciones = "XXXXXXX"
            });

            Assert.AreEqual(true, resultado.Value.Contains("Exitosa"));
        }

        [TestMethod]
        public async Task GuardarAsignacion()
        {
            var resultado = await _ServicioActivo.GuardarAsignacion(new AsignacionViewModel
            {
                IdActivo = 1,
                IdEstatus = 2,
                FechaAsignacion = new System.DateTime(2020, 01, 27, 16, 47, 45),
                NumEmpleado = "E030001"
            });

            Assert.AreEqual(true, resultado.Value.Contains("Exitosa"));
        }


        [TestMethod]
        public async Task ActualizarEmpleado()
        {

            var resultado = await _ServicioEmpleado.ActualizarEmpleado(new EmpleadoViewModel
            {
                NumEmpleadoE = "E030002",
                Nombre = "Prueba2",
                Puesto = "Analista analista",
                CentroCosto = "Telcel",
                Calle = "Av. Insurgentes",
                Numero = "45",
                Ciudad = "Puebla",
                Colonia = "centro",
                CP = "90987",
                EntreCalles = "Pino Suarez y 16 de septiembre"
            });

            Assert.AreEqual(true, resultado.Value.Contains("Exitosa"));

        }

        [TestMethod]
        public async Task ObtenerEmpleado()
        {

            var resultado = await _ServicioEmpleado.ObtenerEmpleado("E030002");
            Assert.AreEqual("Prueba2", resultado.Nombre);

        }

        [TestMethod]
        public async Task GuardarListaComponentes()
        {

            var resultado = await _ServicioComponentes.GuardarListaComponentes(new ComponentesViewModel
            {
                Nombre = "MEMORIA RAM",
                Marca = "DELL",
                Modelo = "E6430 MEMORIA",
                Serie = "200-Pin DDR2 667 SO-DIMM",
                Procesador = "CORE i7",
                DiscoDuro = "500 Gb",
                Ram = "8Gb",
                Anotaciones = "xxxxxx",
                IdActivo = 1
            });

            Assert.AreEqual(true, resultado.Value.Contains("Exitosa"));

        }

        [TestMethod]
        public async Task ObtenerComponentesPorId()
        {
            var resultado = await _ServicioComponentes.ObtenerComponentesPorId(1);
            Assert.AreEqual("ok", resultado.ToList()[0].Nombre);
        }


    }
}
