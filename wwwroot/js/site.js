$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/TblUsuarios/FiltroUsuario/",
        data: {},
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (list) {
            if (list.length == 0) {
                $('#i_empresa_p').removeAttr('hidden');
                $('#i_empresa_n').removeAttr('hidden');
                $('#i_catalogos_n').removeAttr('hidden');
            }
            else {
                if (list[0].idPerfil == 3 && list[0].idRol == 2) {
                    var remove_i_empresa_p = document.getElementById("i_empresa_p");
                    remove_i_empresa_p.parentNode.removeChild(remove_i_empresa_p);
                    var remove_i_empresa_n = document.getElementById("i_empresa_n");
                    remove_i_empresa_n.parentNode.removeChild(remove_i_empresa_n);
                    var remove_i_catalogos_n = document.getElementById("i_catalogos_n");
                    remove_i_catalogos_n.parentNode.removeChild(remove_i_catalogos_n);
                }
            }
        },
        error: function () {
        }
    });

});
