$(document).ready(function () {
    $(".table").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "Nenhum Resultado.",
            "info": "Mostrando _START_ de _END_ do total de _TOTAL_ resultados",
            "infoEmpty": "Mostrando 0 de 0 do total de 0 resultados",
            "infoFiltered": "(Filtrado de _MAX_ total resultados)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrando _MENU_ Resultados",
            "loadingRecords": "Lendo...",
            "processing": "Processando...",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum Resultado encontrado.",
            "paginate": {
                "first": "Primeiro",
                "last": "Ultimo",
                "next": "Proximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": Ativar Ordenacao Crescente.",
                "sortDescending": ": Ativar Ordenacao Decrescente."
            }
        }
    });
});

function Delete(id, url) {
    swal({
        title: "Tem Certeza?",
        text: "Voce nao podera Desfazer!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
    .then((willDelete) => {
        if (willDelete) {
            Ajax(url + `?id=${id}`, "post", null, "Deletado!", "Registro Deletado com Sucesso!", "success");
        } else {
            swal("Cancelado!", "Cancelado Com Sucesso", "error");
        }
    });
}

function Ajax(url, method, data, title, text, swalType, contentType = "application/json") {
    $.ajax({
        url: url,
        method: method,
        data: data,/*object*/
        contentType: contentType,
        complete: function (response, status) {
            if (response.responseJSON.OK) {
                swal(title, text, swalType);
                setTimeout(function () {
                    location.reload();
                }, 1000);
                
            }
            else {
                swal("Erro", "Algo Errado Nao Esta certo!", "error");
            }
        }
    });
}