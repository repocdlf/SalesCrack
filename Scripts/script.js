﻿//Only scripts in front

function logout() {
    location.href = "/Login/Logout";
}

//Scripts end point
$(".button-active-status").on('click', function () {
    let product = $(this).find("input");
    console.log(product)
    $.ajax({
        url: '/Admin/DoChangeProductStatus?idProduct=1&Active=True',
        success: function (respuesta) {
            console.log(respuesta);

        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
});