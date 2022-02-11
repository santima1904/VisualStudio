window.onload = inicializaEventos;

var arrayCategorias
/**
 * Cabecerea:function inicializaEventos()
 * Descripcion: metodo que se llama al principio. Este metodo llamara al metodo de rellenar la tabla con las categorias y anhade el evento click al boton de ver plantas
 * 
 * */
function inicializaEventos() {

    rellenarTabla();
    document.getElementById("botonverplantas").addEventListener("click", adquirirCategoriasSeleccionadas, false);

}

/**
 * 
 * Cabecera: function rellenarTabla()
 * Descripcion: metodo para rellenar la tabla con las categorias 
 * 
 * */
function rellenarTabla() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:2656/api/categorias")
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            arrayCategorias = JSON.parse(miLlamada.responseText)
            crearTabla(arrayCategorias)
        }
        else {
            controlarErrores(miLlamada.status)
        }
    }
    miLlamada.send();
}

/**
 * Cabecera: function crearTabla(arrayCategorias)
 * Descripcion: metodo para crear las filas de la tabla. Tienen  dos columnas, una con el nombre de la categoria, y otro con un checkbox
 * Precondiciones: tabla de categorias creada en el html
 * Postcondiciones: columnas creadas
 * 
 * @param {any} arrayCategorias
 */
function crearTabla(arrayCategorias) {
    for (var i = 0; i < arrayCategorias.length; i++) {
        var fila = document.createElement("tr")
        var nombreCategoria = document.createElement("td")
        var columnaCheck = document.createElement("td")
        nombreCategoria.innerHTML = arrayCategorias[i].nombreCategoria
        var checkbox = document.createElement("input")
        checkbox.type = "checkbox"
        checkbox.name = "check"
        checkbox.id = i
        columnaCheck.appendChild(checkbox)
        fila.appendChild(nombreCategoria)
        fila.appendChild(columnaCheck)
        document.getElementById("tablaCategorias").appendChild(fila)
    }
}

/**
 * Cabecera: function adquirirCategoriasSeleccionadas()
 * Descripcion: metodo recoger los check boxes y llamar al metodo mostrar informe para mostrar los detalles 
 * No he conseguido ver que checkboxes estan seleccionados, tienen un atributo checked pero no he encontrado la forma de acceder a el
 * Precondiciones: ninguna
 * Postcondiciones: detalles mostrados de todas las categorias selecionadas
 */
function adquirirCategoriasSeleccionadas() {
    var checkboxes = document.getElementsByName("check")
    var divpaborrar = document.getElementById("idpaborrar")
    divpaborrar.remove();
    var parrafoLimpio = document.createElement("div");
    parrafoLimpio.id = "idpaborrar";
    document.getElementById("p").appendChild(parrafoLimpio)
    var categoriaSeleccionada

    for (var i = 0; i < checkboxes.length; i++) {
        categoriaSeleccionada = arrayCategorias[checkboxes[i].id]
        mostrarInforme(categoriaSeleccionada)
    }
}

/**
 * Cabecera: function mostrarInforme(categoriaSeleccionada)
 * Descripcion: muestra el titulo de la categoria recibida y deberia mostrar las plantas llamando al metodo mostrarInforme()
 * Precondiciones: categoria diferente de null
 * Postcondiciones: detalles mostrados de la categoria recibida
 * 
 * @param categoriaSeleccionada
 */
function mostrarInforme(categoriaSeleccionada) {
    var tituloCategoria = document.createElement("h2")
    tituloCategoria.innerHTML = categoriaSeleccionada.nombreCategoria
    var divCategoria = document.createElement("div");
    divCategoria.id = categoriaSeleccionada.idCategoria;
    document.getElementById("idpaborrar").appendChild(divCategoria)
    document.getElementById(categoriaSeleccionada.idCategoria).appendChild(tituloCategoria)
    rellenarPlantas(categoriaSeleccionada)
    document.getElementById(categoriaSeleccionada.idCategoria).appendChild(document.createElement("hr"))
}

/**
 * 
 * Cabecera: function rellenarTabla()
 * Descripcion: metodo para rellenar la tabla con las categorias 
 * 
 * */
function rellenarPlantas(categoriaSeleccionada) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:2656/api/Plantas/"+categoriaSeleccionada.idCategoria);
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPlantas = JSON.parse(miLlamada.responseText)
            for (var i = 0; i < arrayPlantas.length; i++) {
                var divPlantas = document.createElement("div")
                divPlantas.innerHTML = arrayPlantas[i].nombre +"     " + arrayPlantas[i].precio + "€"
                document.getElementById(categoriaSeleccionada.idCategoria).appendChild(divPlantas)
                document.getElementById(categoriaSeleccionada.idCategoria).appendChild(document.createElement("br"))
            }
        }
        else {
            controlarErrores(miLlamada.status)
        }
    }
    miLlamada.send();
}

/**
 * 
 * Metodo para comprobar errores
 * 
 * @param {any} int
 */
function controlarErrores(int) {
    switch (int) {
        case 404: alert("Error 404 not found")
            break;
        case 500: alert("Internal server error")
            break;
    }
}

