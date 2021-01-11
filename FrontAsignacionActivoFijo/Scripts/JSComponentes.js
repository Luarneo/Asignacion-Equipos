$(document).ready(function () {
    $('#TablaActivosComponentes').DataTable();
    $(".BorraElemento").css("display", "none");



});

$("#SelectEmpresa").change(function () {

    ValidarListaActivos();
});

$("#SelectUbicacion").change(function () {

    ValidarListaActivos();
});

function ValidarListaActivos() {

    var EmpresaSeleccionada = $("#SelectEmpresa").val();

    if (EmpresaSeleccionada == 1) {
        EmpresaSeleccionada = "ECONTACT"
    }

    if (EmpresaSeleccionada == 2) {
        EmpresaSeleccionada = "SERVINEXT"
    }

    var UbicacionSeleccionada = $("#SelectUbicacion").val();

    if (EmpresaSeleccionada != "" && UbicacionSeleccionada != "") {

        $.ajax({
            url: '/Componentes/MostrarActivos',
            type: 'POST',
            data: {
                Empresa: EmpresaSeleccionada,
                UbicacionId: UbicacionSeleccionada,
            },
            dataType: 'json'
        }).done(function (result) {

            LlenarTablaActivos(result);

        });
    }
}

function LlenarTablaActivos(coleccion) {

    var t = $('#TablaActivosComponentes').DataTable();

    t.clear().draw();               

   

    for (var i = 0; i < coleccion.length; i++) {
            

        t.row.add([
            coleccion[i].SerieImei,
            coleccion[i].NombreClasificacion,
            coleccion[i].NombreArticulo,
            coleccion[i].Marca,
            coleccion[i].ModeloVersion,
            coleccion[i].ProcesadorSim,
            coleccion[i].DiscoDuroPlan,
            coleccion[i].RamLinea,
            '<a href=AgregarComponentes?SS=' + coleccion[i].SerieImei + '&ActivoId=' + coleccion[i].IdActivo + '  class="btn btn-success"><i class="glyphicon glyphicon-plus"><font face="Open Sans, Helvetica, Arial"> Agregar</font></a>',
            '<a href=VerComponentes?ActivoId=' + coleccion[i].IdActivo + '  class="btn btn-info"><i class="glyphicon glyphicon-eye-open"><font face="Open Sans, Helvetica, Arial"> Ver</font></a>'
        ]).draw(false);

     
    }
}

//Oculta columnas no requeridas
$('#TablaActivosComponentes').DataTable({
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

//function LlenarTablaActivos(coleccion) {

//    $('#TablaActivosComponentes tbody').empty();



//    for (var i = 0; i < coleccion.length; i++) {



//        $('#TablaActivosComponentes').append('<tr>' +
//            '<td>' + coleccion[i].SerieImei + '</td>' +
//            '<td>' + coleccion[i].NombreClasificacion + '</td>' +
//            '<td>' + coleccion[i].NombreArticulo + '</td>' +
//            '<td>' + coleccion[i].Marca + '</td>' +
//            '<td>' + coleccion[i].ModeloVersion + '</td>' +

//            '<td> <a href=AgregarComponentes?SS=' + coleccion[i].SerieImei + '&ActivoId=' + coleccion[i].IdActivo + '  class="btn btn-success">Agregar</a></td>' +
//            '<td> <a href=VerComponentes?ActivoId=' + coleccion[i].IdActivo + '  class="btn btn-info">Ver</a></td>' +
//            '</tr>');


//    }
//}


//$('#BtnAgregar').click(function () {
       
//    $.post('/Componentes/AgregandoComponente',
//            function (partialView) {
//                $('#DivSeccionesComponentes').append(partialView);  
//                $("#FrmDatosComponentes").removeData('validator');
//                $("#FrmDatosComponentes").removeData('unobtrusiveValidation');
//                $.validator.unobtrusive.parse($("#FrmDatosComponentes"));
//            },
//            "html"
//        );    
//});


$(document).on("click",".BorraElemento", function () {
    if ($(".ItemComponente").length > 1) {
        $($(this).parents(".ItemComponente")[0]).remove();
    }
    else {
        $(this).hide();
    }   
      
});


$(document).ready(function () {
    $('#TablaComponentesAgregados').DataTable(
        {
            language: {
                url: '/Scripts/spanish.json'
            }
        }
    );
});

$(document).on("change", ".ItemComponente", function () {
    if ($(".ItemComponente").length == 1) {

        $(".BorraElemento").css("display", "none");
    }
    else if ($(".ItemComponente").length > 1) {

        $(".BorraElemento").css("display", "block");    
    }

});









