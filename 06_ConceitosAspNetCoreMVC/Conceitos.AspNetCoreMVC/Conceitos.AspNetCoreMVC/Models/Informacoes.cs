namespace Conceitos.AspNetCoreMVC.Models
{
    public class Informacoes
    {
        public static List<Produto> ListarProdutos()
        {
            return new List<Produto>()
            {
                new Produto() { Codigo = 100, Descricao = "Bicicleta", Preco = 1000 },
                new Produto() { Codigo = 200, Descricao = "Cadeira", Preco = 150 },
                new Produto() { Codigo = 300, Descricao = "Monitor", Preco = 700 }
            };
        }
    }
}
