let fn = require('./funcoes/appCallbacks');

// lista de nomes
let nomes = ['Jonas', 'João', 'Denis', 'Daniela', 'Ana Paula', 'Luciana'];

// condição 1: nomes que terminam com a letra 'a'
let resposta1 = fn.buscar(nomes, function(item) {
    return item.endsWith('a');
})
console.log(resposta1);


// condição 2: nomes que contenham a letra 'y'
let resposta2 = fn.buscar(nomes, item => item.includes('y'));
console.log(resposta2);
