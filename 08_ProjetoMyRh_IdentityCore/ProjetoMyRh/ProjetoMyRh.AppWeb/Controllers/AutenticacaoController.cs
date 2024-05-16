using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyRh.AppWeb.Models.Common;
using ProjetoMyRh.AppWeb.Models.Entities;
using ProjetoMyRh.AppWeb.Services;

namespace ProjetoMyRh.AppWeb.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly AutenticacaoService authService;

        public AutenticacaoController(AutenticacaoService service)
        {
            this.authService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Roles = new SelectList(authService.ListRoles());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if(ModelState.IsValid)
            {
                var novo = await authService.CreateUser(model);   
                if (novo.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in novo.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Registrar();
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogonViewModel model, 
            string? returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                if (await authService.LoginUser(model))
                {
                    Utils.UsuarioLogado!.Usuario = User.Identity!.Name;

                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            var erro = "Você não tem permissão para acessar este recurso!!";
            return View("_Erro", new Exception(erro));
        }

    }
}
