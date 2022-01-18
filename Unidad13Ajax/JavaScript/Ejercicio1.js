window.onload = InicializaEventos;

function InicializaEventos() {
    document.getElementById("btnsaludar").addEventListener("click",saludo, false)
}

function saludo() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET","Hola.html");
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            document.getElementById("divsaludo").innerHTML = miLlamada.responseText;
        }
    }
    miLlamada.send();
}
