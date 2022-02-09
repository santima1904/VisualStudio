window.onload = InicializaEventos;

function InicializaEventos() {
    document.getElementById("btnapellido").addEventListener("click", saludo, false)
}

function saludo() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET","https://crudpersonasaspsantimartinez.azurewebsites.net/api/Personas");
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arraypersonas = JSON.parse(miLlamada.responseText);
            document.getElementById("divapellido").innerHTML = arraypersonas[0].apellidos;
        }
        else {
            document.getElementById("divapellido").innerHTML = "Cargando persona...";
        }
    }
    miLlamada.send();
}
