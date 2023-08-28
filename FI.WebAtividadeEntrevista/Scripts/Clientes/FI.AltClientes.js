let beneficiarioAtual = {};
$(document).ready(function () {
    $('#btnBeneficiarios').show();
    $('#Modal_Beneficiario').hide();
    if (obj) {
        $('#formCadastro #Nome').val(obj.Nome);
        $('#formCadastro #CEP').val(obj.CEP);
        $('#formCadastro #Email').val(obj.Email);
        $('#formCadastro #Sobrenome').val(obj.Sobrenome);
        $('#formCadastro #Nacionalidade').val(obj.Nacionalidade);
        $('#formCadastro #Estado').val(obj.Estado);
        $('#formCadastro #Cidade').val(obj.Cidade);
        $('#formCadastro #Logradouro').val(obj.Logradouro);
        $('#formCadastro #Telefone').val(obj.Telefone);
        $('#formCadastro #CPF').val(cpfMask(obj.CPF));
        idCliente = obj.Id;
    }

    $('#formCadastro').submit(function (e) {
        e.preventDefault();
        
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "CEP": $(this).find("#CEP").val(),
                "Email": $(this).find("#Email").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "Nacionalidade": $(this).find("#Nacionalidade").val(),
                "Estado": $(this).find("#Estado").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),
                "Telefone": $(this).find("#Telefone").val(),
                "CPF": $(this).find("#CPF").val().replace(".", "").replace(".", "").replace("-", "")
            },
            error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success:
            function (r) {
                ModalDialog("Sucesso!", r, urlRetorno);
            }
        });
    })

    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable({
            title: '',
            paging: false, //Enable paging
            pageSize: 10, //Set page size (default: 10)
            sorting: false, //Enable sorting
            defaultSorting: 'Nome ASC', //Set default sorting,
            actions: {
                listAction: urlBeneficiarioList,
            },
            fields: {
                CPF: {
                    title: 'CPF',
                    width: '35%',
                    display: function (data) {
                        return cpfMask(data.record.CPF);
                    }
                },
                Nome: {
                    title: 'Nome',
                    width: '50%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        var dataLoad = {
                            "Nome": data.record.Nome,
                            "CPF": data.record.CPF
                        }
                        beneficiarioAtual = dataLoad;
                        return '<button onclick="carregaDadosBeneficiario()" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                },
                Excluir: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="excluirBeneficiario(' + data.record.Id + ')" class="btn btn-danger btn-sm">Excluir</button>';
                    }
                }
            }
        });

    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable('load');

    $('#formCadastroBeneficiario').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: urlPostBeneficiario,
            method: "POST",
            data: {
                "Nome": $(this).find("#NomeBeneficiario").val(),
                "CPF": $(this).find("#CPFBeneficiario").val().replace(".", "").replace(".", "").replace("-", ""),
                "IdCliente": idCliente
            },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r)
                    $("#formCadastroBeneficiario")[0].reset();
                    if (document.getElementById("gridBeneficiarios"))
                        $('#gridBeneficiarios').jtable('load');
                }
        });
    });

    
})

function verificaBeneficiario(event) {
    let input = event.target
    validaCPF(event);

    if (input.value != "") {
        if ($('#gridBeneficiarios tr > td:contains(' + input.value + ')').length) {
            ModalDialog("Já existe um beneficiário cadastrado para o CPF informado! Por favor, digite novamente.", "");
            input.value = "";
        }
    }
}

function carregaDadosBeneficiario() {
    $('#formCadastroBeneficiario #NomeBeneficiario').val(beneficiarioAtual.Nome);
    $('#formCadastroBeneficiario #CPFBeneficiario').val(cpfMask(beneficiarioAtual.CPF));
}

function excluirBeneficiario(id) {
    $.ajax({
        url: urlDeleteBeneficiario,
        method: "DELETE",
        data: { Id: id },
        error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
        success:
            function (r) {
                $("#formCadastro")[0].reset();
                ModalDialog("Sucesso!", r, urlRetorno);
                if (document.getElementById("gridBeneficiarios"))
                    $('#gridBeneficiarios').jtable('load');
            }
    });
}

function RedirectTela(url) {
    if (url !== "")
        window.location.href = url;
}

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                            ';

    $('body').append(texto);
    $('#' + random).modal('show');
}

function ModalDialogBeneficiario() {
    $('#Modal_Beneficiario').modal('show');
}

