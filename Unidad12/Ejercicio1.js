window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("btn").addEventListener("click", saludar, false);
}

function saludar() {

    alert("Hello World");

}