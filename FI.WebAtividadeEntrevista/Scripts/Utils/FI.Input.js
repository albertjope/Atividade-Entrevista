const formataCPF = (event) => {
    let input = event.target
    input.value = cpfMask(input.value)
}

const cpfMask = (value) => {
    if (!value) return ""
    value = value.replace(/[^\d]/g, "");
    value = value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
    return value
}

const validaCPF = (event) => {
    let input = event.target
    if (input.value != "") {
        if (!verificaCPF(input.value.replace(".", "").replace(".", "").replace("-", ""))) {
            ModalDialog("O CPF informado é inálido! Por favor, digite novamente.", "");
            input.value = "";
        }
    }
}

function verificaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false

    return true;
}

const formataCEP = (event) => {
    let input = event.target
    input.value = cepMask(input.value)
}

const cepMask = (value) => {
    if (!value) return ""
    value = value.replace(/[^\d]/g, "")
        .replace(/(\d{5})(\d)/, '$1-$2')
        .replace(/(-\d{3})\d+?$/, '$1')
    return value
}

const formataTelefone = (event) => {
    let input = event.target
    input.value = telefoneMask(input.value)
}

const telefoneMask = (value) => {
    if (!value) return ""
    value = value.replace(/[^\d]/g, "")
        .replace(/^(\d{2})(\d)/g, "($1) $2")
        .replace(/(\d)(\d{4})$/, "$1-$2");
    return value
}