using Microsoft.AspNetCore.Mvc;
using ProjetoMyRh.ClienteAPI.Models;
using ProjetoMyRh.ClienteAPI.Services;

namespace ProjetoMyRh.ClienteAPI.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly CandidatosService candidatosService;
        public CandidatoController(CandidatosService candidatosService)
        {
            this.candidatosService = candidatosService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarCandidatos()
        {
            try
            {
                var candidatos = await candidatosService.ListarCandidatosAsync();
                return View(candidatos);
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        [HttpGet]
        public IActionResult IncluirCandidato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IncluirCandidato(CandidatoClient candidato)
        {
            try
            {
                await candidatosService.IncluirCandidatoAsync(candidato);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
    }
}
