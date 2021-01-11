//$("#IdEmpresa").on("change", "#NombreEstado", function () {

//    var IdEstadoseleccionado = $("#NombreEstado option:selected").val();

//    $.ajax({
//        url: '/Ubicaciones/ObtenerMunicipios',
//        type: 'GET',
//        data: {
//            IdEstado: IdEstadoseleccionado
//        }
//    }).done(function (resultado) {


//        LlenarSelectMunicipios(resultado);
//    }).fail(function () {
//        console.log("error");
//    });
//});

$("#IdArea").change(function () {

    var IdAreaSeleccionada = $("#IdArea option:selected").val();     

    $.ajax({
        url: '/Activo/ObtenerDepartamentos',
        type: 'GET',
        data: {
            AreaId: IdAreaSeleccionada
        }
    }).done(function (resultado) {
        LlenarSelectDepartamentos(resultado);
    }).fail(function () {
        console.log("error");
    });

});

function LlenarSelectDepartamentos(coleccion) {
    $("#IdDepartamento").empty();
    $("#IdDepartamento").append('<option value="">Selecciona una opción</option>');
    $.each(coleccion, function (i, Elemento) {
        $("#IdDepartamento").append('<option value="' + Elemento.Id + '">' + Elemento.Nombre + '</option>');
    });
}

$("#IdClasificacion").change(function () {

    var IdClasificacionSeleccionada = $("#IdClasificacion option:selected").val();

    $.ajax({
        url: '/Activo/ObtenerArticulos',
        type: 'GET',
        data: {
            ClasificacionId: IdClasificacionSeleccionada
        }
    }).done(function (resultado) {
        LlenarSelectArticulos(resultado);
    }).fail(function () {
        console.log("error");
    });

});

function LlenarSelectArticulos(coleccion) {
    $("#IdArticulo").empty();
    $("#IdArticulo").append('<option value="">Selecciona una opción</option>');
    $.each(coleccion, function (i, Elemento) {
        $("#IdArticulo").append('<option value="' + Elemento.Id + '">' + Elemento.Nombre + '</option>');
    });
}