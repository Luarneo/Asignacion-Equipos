$(document).ready(function () {
    $('#TablaActivos').DataTable();
    //$("#FechaAsignacion").datepicker();
    $("#BtnResponsiva").hide();
});

//$(function () {
//    $('#FechaAsignacion').datepicker();
//});




$("#SelectEmpresa").change(function () {
    
    ValidarListaActivos();       
});

$("#SelectUbicacion").change(function () {

    ValidarListaActivos();
});

function ValidarListaActivos() {

    var EmpresaSeleccionada = $("#SelectEmpresa").val();
    
       

    if (EmpresaSeleccionada == 1) {
        EmpresaSeleccionada = "SERVICIOS INTEGRALES S.A"
    }

    if (EmpresaSeleccionada == 2) {
        EmpresaSeleccionada = "NEOTEC"
    }

    var UbicacionSeleccionada = $("#SelectUbicacion").val();

    if (EmpresaSeleccionada != "" && UbicacionSeleccionada != "") {

        $.ajax({
            url: '/Asignacion/MostrarActivos',
            type: 'POST',
            data: {
                Empresa: EmpresaSeleccionada,
                UbicacionId: UbicacionSeleccionada                
            },
            dataType: 'json'
        }).done(function (result) {
            
            LlenarTablaActivos(result);

        });
    }
}

//Llenado dinamico de tabla de activos
function LlenarTablaActivos(coleccion) {
    
    var t = $('#TablaActivos').DataTable();
    var ubicacion = $("#SelectUbicacion option:selected").html();

 
    t.clear().draw();  

    for (var i = 0; i < coleccion.length; i++) {

       
            t.row.add([
                coleccion[i].SerieImei,
                coleccion[i].NombreClasificacion,
                coleccion[i].NombreArticulo ,
                coleccion[i].Marca,
                coleccion[i].ModeloVersion,
                coleccion[i].ProcesadorSim,
                coleccion[i].DiscoDuroPlan,
                coleccion[i].RamLinea,
                '<button type="button" class="btn btn-success BtnPorActivo" id=' + coleccion[i].IdActivo + ' ><i class="glyphicon glyphicon-refresh"><font face="Open Sans, Helvetica, Arial"> Actualizar</font></button>',
                //'<button type="button" class="btn btn-info BtnDescResp" id=' + coleccion[i].IdActivo + ' ><i class="glyphicon glyphicon-download-alt"><font face="Open Sans, Helvetica, Arial"> Descargar</font></button>',
                '<a href=GenerarResponsivaDescagable?IdActivo=' + coleccion[i].IdActivo + '&Ubicacion=' + ubicacion + ' class="btn btn-info"><i class="glyphicon glyphicon-download-alt"><font face="Open Sans, Helvetica, Arial"> Descargar</font></a>',
            ]).draw(false);
              
    }
}



//Oculta columnas no requeridas
$('#TablaActivos').DataTable({
    language: {
        url: '/Scripts/spanish.json'
    },
    "columnDefs": [
        {
            "targets": [5],
            "visible": false,
           // "searchable": false
        },
        {
            "targets": [6],
            "visible": false,
            //"searchable": false
        },
        {
            "targets": [7],
            "visible": false,
            "searchable": false
        }
    ]
});


   





//Obtiene el id y el numero de serie del elemento seleccionado
$(document).on('click', '.BtnPorActivo', function () {

   var oTable = $("#TablaActivos").dataTable();    
    
    var UbicacionSeleccionada = $('select[name="SelectUbicacion"] option:selected').text();

       
    var SerieSeleccionada = $(this).parents('tr').find('td').html();    
    var ArticuloSeleccionado = $(this).parents('tr').find('td:nth-child(3)').html();
    var MarcaSeleccionada = $(this).parents('tr').find('td:nth-child(4)').html();
    var ModeloSeleccionado = $(this).parents('tr').find('td:nth-child(5)').html();

    // obtienen datos de celdas ocultas en datatable
    var ProcesadorSeleccionado = oTable.fnGetData($(this).parents('tr'))[5];    
    var DiscoSeleccionado = oTable.fnGetData($(this).parents('tr'))[6];
    var RamSeleccionado = oTable.fnGetData($(this).parents('tr'))[7];    
    ////////////////////////////////////////////////7

    var IdSeleccionado = this.id;         

  


    $("#ContenidoAsignarActivo").empty();

    $.ajax({
        url: '/Asignacion/AsignarActivo',
        type: 'GET',
        dataType: 'html',
        data: {
            Serie: SerieSeleccionada,
            ActivoId: IdSeleccionado,
            Articulo: ArticuloSeleccionado,
            Marca: MarcaSeleccionada,
            Modelo: ModeloSeleccionado,
            Procesador: ProcesadorSeleccionado,
            Disco: DiscoSeleccionado,
            Ram: RamSeleccionado,
            Ubicacion: UbicacionSeleccionada
        }       
    }).done(function (data) {

        $("#ContenidoAsignarActivo").html(data);

    });

    $("#ModalAsignarActivo").modal("show");
});




var CalleBase = "";
var NumeroBase = "";
var CiudadBase = "";
var ColoniaBase = "";
var CPBase = "";
var EntreCallesBase = "";


$('#ModalAsignarActivo').on('click', '#BtnBuscarEmpleado', function () {

    

    var EmpleadoCapturado = $("#NumEmpleadoE").val();

    if (EmpleadoCapturado != "") {

        $.ajax({
            url: '/Asignacion/BuscarEmpleado',
            type: 'GET',
            dataType: 'json',
            data: {
                NumEmpleado: EmpleadoCapturado
            }
        }).done(function (data) {

            CalleBase = data.Calle;
            NumeroBase = data.Numero;
            CiudadBase = data.Ciudad;
            ColoniaBase = data.Colonia;
            CPBase = data.CP;
            EntreCallesBase = data.EntreCalles;

            
                     

            if (data.NumEmpleadoE != null) {

                $('#ModalAsignarActivo').find('#Nombre').val(data.Nombre);
                $('#ModalAsignarActivo').find('#Puesto').val(data.Puesto);
                $('#ModalAsignarActivo').find('#CentroCosto').val(data.CentroCosto);
                $('#ModalAsignarActivo').find('#Calle').val(data.Calle);
                $('#ModalAsignarActivo').find('#Numero').val(data.Numero);
                $('#ModalAsignarActivo').find('#Ciudad').val(data.Ciudad);
                $('#ModalAsignarActivo').find('#Colonia').val(data.Colonia);
                $('#ModalAsignarActivo').find('#CP').val(data.CP);
                $('#ModalAsignarActivo').find('#EntreCalles').val(data.EntreCalles);
                $('#ModalAsignarActivo').find('#NumEmpleadoA').val(data.NumEmpleadoE);
                
               
                    GenerarBotonResposiva();
                              
                
            }
            else {
                alert("No se encontro el colaborador");
            }

        }).fail(function () {
            alert("Error al realizar la busqueda");
        });
    }
    else {
        alert("Por favor capture un número de colaborador");
    }
   
});


$('#ModalAsignarActivo').on('change', '#NumEmpleadoE', function () {

    $('#ModalAsignarActivo').find('#Nombre').val("");
    $('#ModalAsignarActivo').find('#Puesto').val("");
    $('#ModalAsignarActivo').find('#CentroCosto').val("");
    $('#ModalAsignarActivo').find('#Calle').val("");
    $('#ModalAsignarActivo').find('#Numero').val("");
    $('#ModalAsignarActivo').find('#Ciudad').val("");
    $('#ModalAsignarActivo').find('#Colonia').val("");
    $('#ModalAsignarActivo').find('#CP').val("");
    $('#ModalAsignarActivo').find('#EntreCalles').val("");
    $('#ModalAsignarActivo').find('#NumEmpleadoA').val("");

    CalleBase = "";
    NumeroBase = "";
    CiudadBase = "";
    ColoniaBase = "";
    CPBase = "";
    EntreCallesBase = "";

    var a = document.getElementById('BtnResponsiva');
    a.href = '#'    
});

// Función para generar responsiva de excel
function GenerarBotonResposiva() {

   

        //Encabezado
        var ContenidoNombre = $('#ModalAsignarActivo').find('#Nombre').val();
        var ContenidoPuesto = $('#ModalAsignarActivo').find('#Puesto').val();
        var ContenidoLugar = $('#ModalAsignarActivo').find('#UbicacionS').val();
        var ContenidoNumeroE = $('#ModalAsignarActivo').find('#NumEmpleadoE').val();
        var ContenidoArea = $('#ModalAsignarActivo').find('#CentroCosto').val();
        var d = new Date();
        var strDate = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();
        var ContenidoFecha = strDate;


        //Contenido
        var ContenidoMarca = $('#ModalAsignarActivo').find('#MarcaS').val();
        var ContenidoModelo = $('#ModalAsignarActivo').find('#ModeloS').val();
        var ContenidoSerie = $('#ModalAsignarActivo').find('#SerieActivo').val();
        var ContenidoProcesador = $('#ModalAsignarActivo').find('#ProcesadorS').val();
        var ContenidoDisco = $('#ModalAsignarActivo').find('#DiscoS').val();
        var ContenidoRam = $('#ModalAsignarActivo').find('#RamS').val();

        //Datos Colaborador (Pie de pagina)
        var ContenidoCalle = $('#ModalAsignarActivo').find('#Calle').val();
        var ContenidoNum = $('#ModalAsignarActivo').find('#Numero').val();
        var ContenidoColonia = $('#ModalAsignarActivo').find('#Colonia').val();
        var ContenidoCP = $('#ModalAsignarActivo').find('#CP').val();
        var ContenidoCiudad = $('#ModalAsignarActivo').find('#Ciudad').val();
        var ContenidoEntreCalles = $('#ModalAsignarActivo').find('#EntreCalles').val();


        //Identificador para impresion
        var ContenidoArticulo = $('#ModalAsignarActivo').find('#ArticuloS').val();



        var a = document.getElementById('BtnResponsiva');
        a.href = ""
        var URL = "GenerarReponsiva?Nombref=" + ContenidoNombre +
            "&Puestof=" + ContenidoPuesto +
            "&NumEmpf=" + ContenidoNumeroE +
            "&Areaf=" + ContenidoArea +
            "&Marcaf=" + ContenidoMarca +
            "&Modelof=" + ContenidoModelo +
            "&Serief=" + ContenidoSerie +
            "&Procesadorf=" + ContenidoProcesador +
            "&Discof=" + ContenidoDisco +
            "&Ramf=" + ContenidoRam +
            "&Callef=" + ContenidoCalle +
            "&Numf=" + ContenidoNum +
            "&Coloniaf=" + ContenidoColonia +
            "&CPf=" + ContenidoCP +
            "&Ciudadf=" + ContenidoCiudad +
            "&EntreCallesf=" + ContenidoEntreCalles +
            "&Articulof=" + ContenidoArticulo +
            "&Fechaf=" + ContenidoFecha +
            "&Ubicacionf=" + ContenidoLugar
        a.href = URL           
  
}

// validación de cambios en datos del empleado
$('#ModalAsignarActivo').on('submit', function () {

    var Fechavalid = $("#FechaAsignacion").val();
    var Estatusvalid = $("#IdEstatus").val();
    var Nombrevalid = $("#Nombre").val();

    if (Fechavalid != "" && Estatusvalid != "" && Nombrevalid != "") {
        var CalleCapurada = $("#Calle").val();
        var NumeroCapurado = $("#Numero").val();
        var CiudadCapturada = $("#Ciudad").val();
        var ColoniaCapurada = $("#Colonia").val();
        var CPCapurado = $("#CP").val();
        var EntreCallesCapturadas = $("#EntreCalles").val();

        if (CalleBase != CalleCapurada || NumeroBase != NumeroCapurado || CiudadBase != CiudadCapturada || ColoniaBase != ColoniaCapurada || CPBase != CPCapurado || EntreCallesBase != EntreCallesCapturadas) {
            $("#ActualizacionEmpleado").prop("checked", true);
        }
        else {
            $("#ActualizacionEmpleado").prop("checked", false);
        }

    }
    else {

        if (Fechavalid == "") {
            $("#ValidFecha").html("Campo requerido");
        }

         if (Estatusvalid == "") {
             $("#ValidEstatus").html("Campo requerido");
         }

        if (Nombrevalid == "") {
            $("#ValidColaborador").html("Campo requerido");
        }

        return false;
    }


   
});

//Verifica si hay url armada de boton para generar responsiva
$('#ModalAsignarActivo').on('click', '#BtnResponsiva', function () {
       
    var a = document.getElementById('BtnResponsiva');    
    var ultimoCaracter = a.href.charAt(a.href.length - 1);    
     
    //var FechaCapturada = $("#FechaAsignacion").val();

    var NombreCapturado = $("#Nombre").val();

    //if (NombreCapturado == '') {
        if (ultimoCaracter == '#') {

            if (NombreCapturado == "") {
                $("#ValidColaborador").html("Campo requerido");
            }
        }
    //}

    
    //if (FechaCapturada == '') {
    //    alert('Por favor capture la fecha de asignación')
    //}
       
});

$("#ModalAsignarActivo").on("change", "#NumEmpleadoE", function () {
    $("#ValidColaborador").html("");
});

$("#ModalAsignarActivo").on("change", "#FechaAsignacion", function () {
    $("#ValidFecha").html("");
});

$("#ModalAsignarActivo").on("change", "#IdEstatus", function () {
    $("#ValidEstatus").html("");
});



