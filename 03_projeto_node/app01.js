let moment = require('moment');
//moment.locale('ja-jp');
moment.locale('pt-br');

let now = moment();
//let now1 = new Date().getTime();
console.log(now);
console.log(now.format("DD/MM/yyyy - dddd (MMMM)"))
//console.log(now1);