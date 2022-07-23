(document).ready(function () {
    var v = '@ViewBag.ActivaRol'
    if (v == 1) {
        document.getElementById("i_empresa_p").style.visibility = "hidden";
        document.getElementById("i_empresa_n").style.visibility = "hidden";
        document.getElementById("i_catalogos_n").style.visibility = "hidden";
    } else {
        document.getElementById("i_empresa_p").style.visibility = "visible";
        document.getElementById("i_empresa_n").style.visibility = "visible";
        document.getElementById("i_catalogos_n").style.visibility = "visible";
    }
});
