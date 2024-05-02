using Conceitos.AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conceitos.AspNetCoreMVC.Controllers
{
    public class ConceitosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Exemplos de actions:
        // 1. Action retornando uma string
        public string MostrarTexto()
        {
            return "Texto obtido no Controller Conceitos";
        }

        // 2. Action retornando um arquivo PDF
        public FileResult MostrarPdf()
        {
            return File("~/pdf/AZ-400-DevOps_01.pdf", "application/pdf");
        }

        // 3. Action retornando uma View
        public IActionResult MostrarConteudo()
        {
            return View();
        }

        // 4. Action enviando os dados de um produto para a View
        public IActionResult MostrarProduto()
        {
            Produto produto = new Produto()
            {
                Codigo = 10, Descricao = "Caixa de Som", Preco = 200
            };

            return View(produto);
        }

        // 5. Action enviando uma lista de produtos para  View
        public IActionResult MostrarLista()
        {
            var lista = Informacoes.ListarProdutos();
            return View(lista);
        }
    }
}
