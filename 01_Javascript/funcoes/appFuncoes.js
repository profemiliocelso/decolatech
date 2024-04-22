// função que recebe dois parametros numericos e retorna sua soma
// 1. função nomeada
function calcularSoma(valor1, valor2) {

    if(typeof(valor1) != 'number' || typeof(valor2) != 'number'){
        throw new TypeError('Os parâmetros devem ser numéricos');
    }
    return valor1 + valor2;
}

exports.somar = calcularSoma;

// 2. função anônima
exports.buscarMaior = function (a, b = 0) {
    if(typeof(a) != 'number' || typeof(b) != 'number'){
        throw new TypeError('Os parâmetros devem ser numéricos');
    }
    return a > b ? a : b;
}