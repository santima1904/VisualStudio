window.onload = inicializaEventos;
function inicializaEventos() {
    document.getElementById("btnBorrar").addEventListener("click", buscarPersona, false);
}
function buscarPersona() {
    var nombreAbUSCAR = document.getElementsByTagName("input")[0].value;
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudpersonasaspcr7.azurewebsites.net/api/Persona");
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            alert(miLlamada.readyState)
        }
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            for (var i = 0; i < arrayPersonas.length; i++) {
                var fila = document.createElement("tr");
                var columnaId = document.createElement("td");
                var columnaName = document.createElement("td");
                var columnaApellidos = document.createElement("td");
                columnaId.innerHTML = arrayPersonas[i].id
                columnaName.innerHTML = arrayPersonas[i].nombre
                columnaApellidos.innerHTML = arrayPersonas[i].apellidos
                fila.appendChild(columnaId)
                fila.appendChild(columnaName)
                fila.appendChild(columnaApellidos)
                document.getElementById("tablePersonas").appendChild(fila)
            }
        }
    }
    miLlamada.send();
}
function borrarPersona(int) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", "https://crudpersonasaspcr7.azurewebsites.net/api/Persona/" + int);
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            alert("Creo que se ha borrado")
        }
    }
    miLlamada.send();
}