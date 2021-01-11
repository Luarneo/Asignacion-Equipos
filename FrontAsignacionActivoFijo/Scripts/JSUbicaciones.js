$(Document).ready(function () {
    

    $("#NvaUbic").click(function () {

       
        $("#contenidoNuevaUbicacion").empty();
                
        $.ajax({
            url: '/Ubicaciones/NuevaUbicacion',
            type: 'GET',
            dataType: 'html'
        }).done(function (data) {

            $("#contenidoNuevaUbicacion").html(data);
                    
        });

        $("#NuevaUbicacion").modal("show");
    
    });



    function LlenarSelectMunicipios(coleccion) {

      
        $("#IdMunicipio").empty();
        $("#IdMunicipio").append('<option value="">Selecciona una opción</option>');
        $.each(coleccion, function (i, Elemento) {
            $("#IdMunicipio").append('<option value="' + Elemento.Id + '">' + Elemento.Nombre + '</option>');
        });
    }

    $("#contenidoNuevaUbicacion").on("change", "#NombreEstado", function () {

        var IdEstadoseleccionado = $("#NombreEstado option:selected").val();

        $.ajax({
            url: '/Ubicaciones/ObtenerMunicipios',
            type: 'GET',
            data: {
                EstadoId: IdEstadoseleccionado
            }
        }).done(function (resultado) {


            LlenarSelectMunicipios(resultado);
        }).fail(function () {
            console.log("error");
        });
    });

   


     //Guardar Nueva Ubicación
    $("#contenidoNuevaUbicacion").on("click", "#BtnGuardarUbicacion", function () {


        $("#ValidNombre").html("Campo requerido");
                
        var EstadoSeleccionado = $("#NombreEstado option:selected").val();
        var IdMunicipioSeleccionado = $("#IdMunicipio option:selected").val();
        var NombreIngresado = $("#Nombre").val();     
        var EstatusSeleccionado = $("#Estatus").prop("checked");    

                     
        if (EstadoSeleccionado != "" && IdMunicipioSeleccionado != "" && NombreIngresado != "" ){
            $.ajax({
            url: '/Ubicaciones/GuardarNuevaUbicacion',
            type: 'POST',
            data: {
                IdMunicipio: IdMunicipioSeleccionado,
                Nombre: NombreIngresado,
                Estatus: EstatusSeleccionado
            },
            dataType: 'json'
        }).done(function (result) {
            $("#NuevaUbicacion .close").click()
            if (typeof result[0] != 'undefined' && typeof result[1] != 'undefined') {
                $("#AlertaDiv").append('<div class="alert alert-dismissible alert-' + result[0] + '"><button class="close" type="button" data-dismiss="alert">&times;</button><strong>' + result[1] + '</strong> </div>');

            }
        });
        }
        else {
            if (EstadoSeleccionado == "") {
                $("#ValidEstado").html("Campo requerido");
            }
            if (IdMunicipioSeleccionado == "") {
                $("#ValidMunicipios").html("Campo requerido");
            }
            if (NombreIngresado == "") {
                $("#ValidNombre").html("Campo requerido");
            }
        }

      
        
    });



});


$("#contenidoNuevaUbicacion").on("change", "#NombreEstado", function () {
    $("#ValidEstado").html("");
});

$("#contenidoNuevaUbicacion").on("change", "#IdMunicipio", function () {
    $("#ValidMunicipios").html("");
});

$("#contenidoNuevaUbicacion").on("change", "#Nombre", function () {
    $("#ValidNombre").html("");
});


$(document).ready(function () {
    $('#TablaUbicaciones').DataTable(
        {
            language: {
                url: '/Scripts/spanish.json'
            }
        }
    );
});

    //obtiene el id y el estatus seleccionado de la ubicación a actualizar 
$(".claseestatus").change(function () {
       
    var id = $(this).attr("dataid");
    var estatusselec = $(this).prop('checked');
   
    ActualizarEstatus(id, estatusselec);

});

     //Funcion para actualizar estatus de la ubicación
function ActualizarEstatus(IdUbicacion, NuevoEstatus) {

    $.ajax({
        url: '/Ubicaciones/ActualizarEstatusUbicacion',
        type: 'GET',
        data: {
            IdUbicacion: IdUbicacion,
            estatus: NuevoEstatus
        }
    }).done(function () {
        $("#AlertaDiv").append('<div class="alert alert-dismissible alert-success"><button class="close" type="button" data-dismiss="alert">&times;</button><strong>El estatus se ha actualizado exitosamente</strong> </div>');
    }).fail(function () {
        $("#AlertaDiv").append('<div class="alert alert-dismissible alert-danger"><button class="close" type="button" data-dismiss="alert">&times;</button><strong>Error al actualizar estatus</strong> </div>');
    });
}




