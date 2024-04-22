// lista de nomes
let nomes = ['Jonas', 'João', 'Denis', 'Daniela', 'Ana Paula', 'Luciana'];

let resposta1 = nomes.filter(item => item.endsWith('a'));
console.log(resposta1);

// definindo um objeto com duas propriedades: nome e idade
let pessoa = { 
    nome: 'Jose',
    idade: 23
};

// definindo uma lista de objetos.
let pessoas = [
    {
        nome: 'Ana Paula',
        idade: 32
    }, 
    {
        nome: 'Jose Bonifacio',
        idade: 45
    }, 
    {
        nome: 'Pradilina Soares',
        idade: 30
    },
    pessoa
];

//console.log(pessoas);

// definindo um objeto "complexo"
let empresa = {
    descricao: 'Avanade',
    cursos: ['Angular', 'Java', '.NET'],
    funcionarios: pessoas
};

//console.log(empresa);

// efetuando buscas na lista de pessoas
let lista = pessoas.filter(p => p.idade <= 30);
console.log(lista);
