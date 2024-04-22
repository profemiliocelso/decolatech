// definindo um objeto com duas propriedades: nome e idade
let pessoa = { 
    nome: 'Jose',
    idade: 23
};

// definindo uma lista de objetos.
let pessoas = [
    { nome: 'Ana Paula', idade: 32 }, 
    { nome: 'Jose Bonifacio', idade: 45 }, 
    { nome: 'Pradilina Soares', idade: 30 },
    { nome: 'Ana Paula', idade: 40 }, 
    pessoa
];

// funcao map()
 let lista = pessoas.map((item, index) => {
    return item.nome + " - " + item.idade;
 });

 //console.log(lista);

 lista = pessoas.map((item, index) => {
    return { 
        posicao: index, 
        aluno: item.nome
    };
 });

 //console.log(lista);

 // exercicio: pesquisar (map javascript) - sobre o uso do map contendo callback 
 // com 3 parametros (usar as informações que julgar necessário)
 lista = pessoas.map((item, index, arr) => {
    if(item.nome == arr[0].nome){
        return {
            posicao: index,
            nome: item.nome,
            idade: item.idade
        }
    } else {
        return `Nome diferente na posição ${index}, diferente de ${arr[0].nome}`;
    }
 });

 console.log(lista);