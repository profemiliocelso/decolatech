using Conceitos.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conceitos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /*
         * WebAPI utiliza alguns padrões para sua execução:
         * 
         * - todos os actions, se nada for especificado, 
         *   são executados como HTTP GET. A lista de parâmetros
         *   diferencia estes actions.
         * 
         */
        [HttpGet]
        public string ApresentarTexto()
        {
            return "Asp.Net Core WebAPI";
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Execução do método HTTP Get, com valor {id}";
        }
        [HttpGet("exibir/{id}")]
        public string GetText(int id) 
        {
            return $"Execução de outra action com valor {id}";
        }

        // Endpoint para listar os cursos: parte1
        [HttpGet]
        [Route("primeiralista")]
        public IActionResult GetCursos1() 
        { 
            return Ok(Listas.ListarCursos());
        }

        // Endpoint para listar os cursos: parte 2
        [HttpGet]
        [Route("segundalista")]
        public IActionResult GetCursos2()
        {
            try
            {
                var lista = Listas.ListarCursos();
                if(lista.Count() < 5)
                {
                    throw new Exception("A lista é muito pequena");
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status=400, message=ex.Message });
            }

        }
    }
}
