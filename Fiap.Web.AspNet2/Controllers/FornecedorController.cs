using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet2.Controllers
{
    public class FornecedorController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            //if (string.IsNullOrWhiteSpace(fornecedorViewModel.CNPJ))
            //{
            //    ModelState.AddModelError("CNPJ", "CNPJ Inválido");
            //}
            //if (string.IsNullOrWhiteSpace(fornecedorViewModel.RazaoSocial))
            //{
            //    ModelState.AddModelError("RazaoSocial", "RazaoSocial Inválida");
            //}
            //if (string.IsNullOrWhiteSpace(fornecedorViewModel.Telefone))
            //{
            //    ModelState.AddModelError("Telefone", "Telefone Inválido");
            //}

            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Cliente");
        }
    }
}
