using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(loginViewModel.Login.Equals("Bruno") && loginViewModel.Senha == "1234")
            {
                TempData["mensagem"] = "Login Efetuado com sucesso!";
                loginViewModel.Nome = "Bruno Fernandes";
                HttpContext.Session.SetString("usuarioLogado", loginViewModel.Nome);
            }
            else
            {
                HttpContext.Session.SetString("usuarioLogado", "");
                TempData["mensagem"] = "Login ou senha inválido.";
            }
            return RedirectToAction("Index");
        }
    }
}
