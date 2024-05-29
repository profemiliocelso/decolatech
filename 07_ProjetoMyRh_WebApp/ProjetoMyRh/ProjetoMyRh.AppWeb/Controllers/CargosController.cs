using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyRh.AppWeb.Models.DTO;
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
        public IActionResult ListarCargos(int idArea)
        {
            // o parametro id se refere ao id da área
            try
            {
                ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");

                return View(cargosService.ListarCargos(idArea));
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }            
        }

        [HttpGet]
        public IActionResult ListarCargosDTO(int idArea)
        {
            try
            {
                ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");

                //return View(cargosService.ListarCargosDTO(idArea));
                //return View(cargosService.ListarCargosJoin(idArea));
                return View(cargosService.ListarCargosLINQ(idArea));
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult ListarCargosAjax(int idArea)
        {
            try
            {
                ViewBag.ListaDeAreas = new SelectList(areasService.Listar(), "Id", "Descricao");
                if(idArea == 0)
                {
                    return View();
                }
                return PartialView("_ListagemCargos", cargosService.ListarCargosDTO(idArea));

            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult Remover(int idCargo)
        {
            string urlAnterior = Request.Headers["Referer"].ToString();
            cargosService.Remover(cargosService.Buscar(idCargo));
            return Redirect(urlAnterior);
        }

    }
}
