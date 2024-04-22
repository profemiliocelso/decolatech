let promise = new Promise( (resolve, reject) => {
    // como exemplo, criaremos um numero aleatorio entre 0 e 1
    let x = Math.random(); // ]0, 1[
    if(x > 0.5) {
        resolve("Valor aceitável: " + x);
    } else {
        reject("Valor Inválido!!!! " + x);
    }
} );

promise
    .then(s => s.toUpperCase())
    .then(s => console.log(s))
    .catch( erro => console.error(erro) );