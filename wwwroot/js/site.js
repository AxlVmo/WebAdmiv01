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
                $('#i_centro_n').removeAttr('hidden');
                $('#i_consulta_n').removeAttr('hidden');
                $('#i_resumen_n').removeAttr('hidden');           
            }
            else {              
                if (list[0].idPerfil == 3 && list[0].idRol == 2 && list[0].idCorpCent == 2) {               
                    $('#i_centro_n').removeAttr('hidden');
                }
                if (list[0].idPerfil == 1 && list[0].idRol == 2 && list[0].idCorpCent == 1 && list[0].idArea == 1) {
                    $('#i_empresa_d').removeAttr('hidden');
                    $('#i_empresa_p').removeAttr('hidden');
                    $('#i_empresa_n').removeAttr('hidden');
                    
                    $('#i_catalogos_c').removeAttr('hidden');
                    $('#i_catalogos_u').removeAttr('hidden');
                    $('#iCorpCent').removeAttr('hidden');
                }
                if (list[0].idPerfil == 2 && list[0].idRol == 2 && list[0].idCorpCent == 1 && list[0].idArea == 2) {
                    $('#i_empresa_d').removeAttr('hidden');
                    $('#i_empresa_p').removeAttr('hidden');
                    $('#i_empresa_n').removeAttr('hidden');
                    
                    $('#i_catalogos_c').removeAttr('hidden');
                    $('#i_catalogos_u').removeAttr('hidden');
                    $('#iCorpCent').removeAttr('hidden');
                }
            }
        },
        error: function () {      
        }
    });

});
