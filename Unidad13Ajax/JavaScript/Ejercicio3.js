window.onload = InicializaEventos;

function InicializaEventos() {
    document.getElementById("btnborrar").addEventListener("click", borrar, false)
}

function borrar() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", "https://crudpersonasaspsantimartinez.azurewebsites.net/api/Personas/" + document.getElementById("boxId").nodeValue);
    //miLlamada.onreadystatechange = function () {
    //    if (miLlamada.readyState == 4 && miLlamada.status == 200) {
    //        document.getElementById("divapellido").innerHTML = arraypersonas[0].apellidos;
    //    }
    //}
    miLlamada.send();
}
