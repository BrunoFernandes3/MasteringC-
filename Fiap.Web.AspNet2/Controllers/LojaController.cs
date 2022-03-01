using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet2.Controllers
{
    public class LojaController : Controller
    {
        private readonly ILojaRepository _lojaRepository;

        public LojaController(ILojaRepository lojaRepository)
        {
            _lojaRepository = lojaRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var loja = _lojaRepository.FindAll();
            return View(loja);
        }
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var loja = _lojaRepository.FindById(id);
            return View(loja);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var loja = _lojaRepository.FindById(id);
            //  ViewBag.Lojas = lojaRepository.FindAll();
            return View(loja);
        }
        [HttpPost]
        public IActionResult Editar(LojaModel lojaModel)
        {
            _lojaRepository.Update(lojaModel);
            TempData["mensagemSucesso"] = $"Loja  editado com sucesso";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(LojaModel lojaModel)
        {
            _lojaRepository.Insert(lojaModel);
            TempData["mensagemSucesso"] = $"Loja {lojaModel.LojaNome} cadastrado com sucesso";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _lojaRepository.Delete(id);
            TempData["mensagemSucesso"] = "Loja excluido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
