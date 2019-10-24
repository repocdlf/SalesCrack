//Only scripts in front

function logout() {
    location.href = "/Login/Logout";
}

//Scripts end point
$(".button-active-status").on('click', function () {
    let product = $(this).find("input");
    $.ajax({
        url: '/Admin/DoChangeProductStatus?idProduct=' + product.attr('id'),
        success: function (respuesta) {
            console.log("Cambio de estado exitoso");
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
});

//Todo
function vender(idProduct) {
    location.href = "/Seller/Sell?idProduct=" + idProduct;
}