
$(document).ready(function () {

    $("#IdCurso").selectpicker();
    $("#insereNovoCurso").click(function () {
        $("#modal").modal();
    });
})

$("#novoCurso").click(function (e) {
    e.preventDefault();
    var url = "../Curso/Inserir";
    var valores =
    {
        nomeCurso: $("#NomeCurso").val()
    }
    console.log(valores);
    $.ajax({
        type: "POST",
        url: url,
        data: valores,
        success: function (result) {
            $("#IdCursoSelecionado").empty(),
            $("#IdCursoSelecionado").append('<option value="">Curso...</option>'),
            $.each(result, function (i, item) {
                $("#IdCursoSelecionado").append('<option value="' + item.Value + '">' +
                    item.Text + '</option>');
            });
            console.log(result);
            $("#IdCursoSelecionado").selectpicker("refresh");
            $("#cadastroCurso").modal("hide");
            $.toast({
                heading: 'Success',
                text: 'O Novo curso foi cadastrado com sucesso',
                showHideTransition: 'slide',
                icon: 'success'
            });
        }
    });
});

$("#salvaModulo").click(function (e) {
    var url = "Inserir";
    var valores =
    {
        nomeModulo: $("#nomeModulo").val(),
        IdCurso: $("#IdCursoSelecionado").val()
    }
    $.ajax({
        type: "POST",
        url: url,
        data: valores,
        success: function (result) {
            console.log(result);
            $.toast({
                heading: 'Success',
                text: "O módulo " + result + " foi cadastrado com sucesso",
                showHideTransition: 'slide',
                icon: 'success'
            });
            $(':input')
                .not(':button, :submit, :reset, :hidden')
                .val('')
                .removeAttr('checked')
                .removeAttr('selected');
        }
    });
});