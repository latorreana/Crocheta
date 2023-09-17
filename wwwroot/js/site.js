// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validaTelefone() {
    var telefone = document.getElementById("telefone");

    if (telefone.value.length < 11) {
        alert("Digite seu DDD + número de telefone, por favor.")
        document.getElementById("telefone").style.color = "red";
        return false;
    }
    else {
        document.getElementById("telefone").style.color = "green";
        return true;
    }
}

function validaEmail() {
    var email = document.getElementById("campoEmail");

    if (email.value == "" || email.value.indexOf('@') == -1 || email.value.indexOf('.') == -1) {
        alert("Digite um e-mail válido, por favor.")
        document.getElementById("campoEmail").style.color = "red";
        return false;
    }
    else {
        document.getElementById("campoEmail").style.color = "green";
        return true;
    }
}