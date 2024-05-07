using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyRh.AppWeb.Models.Entities;
using ProjetoMyRh.AppWeb.Services;

namespace ProjetoMyRh.AppWeb.Controllers
{
    public class CargosController : Controller
    {
        private readonly AreasService areasService;
        private readonly CargosService cargosService;

        public CargosController(
            AreasService areasService, 
            CargosService cargosService)
        {
            this.areasService = areasService;
            this.cargosService = cargosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdicionarCargo()
        {
            ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarCargo(Cargo cargo)
        {
            try
            {
                if(cargo.AreaId == 0)
                {
                    ModelState.AddModelError("AreaId", "Nenhuma área foi selecionada");
                }

                if (!ModelState.IsValid)
                {
                    return AdicionarCargo();
                }
                cargosService.Adicionar(cargo);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("_Erro", e);                
            }
        }

        [HttpGet]
        public IActionResult ListarCargos(int id)
        {
            // o parametro id se refere ao id da área
            return View();
        }
    }
}
