function ComputarVoto(valor) {
    $.ajax({
        url: location.href + "api/VotoApi/Votar?idVoto="+valor,
        data: { idVoto: valor },
        type: 'POST'
    }).done(function (data) {
        Swal.fire({
            position: 'center',
            type: 'success',
            title: 'Voto computado com sucesso!',
            showConfirmButton: false,
            timer: 1500
        })
    }).fail(function (error) {
        Swal.fire({
            position: 'center',
            type: 'error',
            title: 'Ocorreu um erro ao computar seu voto. Tente novamente',
            showConfirmButton: false,
            timer: 1500
        })
    }).always(function () {

    });
}
$body = $("body");

$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});