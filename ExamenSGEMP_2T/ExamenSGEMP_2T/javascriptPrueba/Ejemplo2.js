window.onload = inicializaEventos;
function inicializaEventos() {
    document.getElementById("btnSaludar").addEventListener("click", saludo, false);
}
function saludo() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "Hola.html");
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            document.getElementById("divSaludo").innerHTML = miLlamada.responseText;
        }
    }
    miLlamada.send();
}