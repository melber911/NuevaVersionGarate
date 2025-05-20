// Referencia al campo de código de usuario
const inputCodigoUsuario = document.getElementById('i_codigo_usuario');
const mensajeUsuario = document.getElementById('mensaje_usuario');
// Función para agregar un número al campo de código
function agregarNumero(numero) {
    inputCodigoUsuario.value += numero;
}

// Función para limpiar el campo de código
function limpiarCodigo() {
    inputCodigoUsuario.value = '';
}

// Función para retroceder (eliminar el último carácter)
function borrarCodigo() {
    if (inputCodigoUsuario.value.length > 0) {
        // Elimina el último carácter del valor actual
        inputCodigoUsuario.value = inputCodigoUsuario.value.slice(0, -1);
    }
}

// Función para verificar el código
function ingresarCodigo() {
    const codigo = inputCodigoUsuario.value.trim(); // Elimina espacios innecesarios

    if (codigo === '') {
        mostrarMensaje('Por favor, ingrese su contraseña');
        return;
    }
    // Realizar la validación con el servidor
    $.ajax({
        url: '/TuControlador/ValidarUsuario', // Ajusta la ruta según tu configuración
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ codigoUsuario: codigo }), // Enviar el código como JSON
        success: function (response) {
            if (response.exito) {
                mostrarMensaje('¡Acceso concedido!');
                // Realiza aquí las acciones para un acceso exitoso
            } else {
                mostrarMensaje(response.mensaje || 'Código incorrecto.');
            }
        },
        error: function () {
            mostrarMensaje('Ocurrió un error al validar el código. Intente nuevamente.');
        }
    });

    limpiarCodigo(); // Opcional: limpiar el campo después de enviar la solicitud
}
// Función para mostrar mensajes
function mostrarMensaje(mensaje, color = 'red') {
    mensajeUsuario.textContent = mensaje;
    mensajeUsuario.style.color = color; // Cambiar color del texto
    mensajeUsuario.style.display = 'block'; // Mostrar el contenedor
    setTimeout(() => {
        mensajeUsuario.style.display = 'none'; // Ocultar el mensaje después de 3 segundos
    }, 3000); // Tiempo de desaparición
}
// Asignación de eventos a los botones numéricos
document.querySelectorAll('.btn_numero').forEach((button) => {
    button.addEventListener('click', function () {
        agregarNumero(button.textContent.trim());
    });
});

// Asignación de evento al botón de limpiar
document.getElementById('btn_limpiar_logeo').addEventListener('click', limpiarCodigo);
// Asignación de evento al botón de cancelar
const btn_cancelar = document.querySelector('.btn_cancelar');
if (btn_cancelar) {
    btn_cancelar.addEventListener('click', limpiarCodigo);
}
// Asignar evento al botón Retroceder
const btnBackspace = document.querySelector('.btn_backspace');
if (btnBackspace) {
    btnBackspace.addEventListener('click', borrarCodigo);
}

// Asignación de evento al botón de ingresar
const btnIngresar = document.getElementById('btn_ingresar');
if (btnIngresar) {
    btnIngresar.addEventListener('click', ingresarCodigo);
}
