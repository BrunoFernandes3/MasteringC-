using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILojaRepository _lojaRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ILojaRepository lojaRepository)
        {
            _produtoRepository = produtoRepository;
            _lojaRepository = lojaRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var produto = _produtoRepository.FindAll();
            return View(produto);
        }
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }
        [HttpGet]
        public IActionResult Editar(int id) 
        {
            var lista = _lojaRepository.FindAll();
            var produtoVM = new ProdutoLojaViewModel();
            var produtoModel = _produtoRepository.FindById(id);
            produtoVM.Produto = produtoModel;
            produtoVM.LojaId = produtoModel.ProdutoLoja.Select( l => l.LojaId).ToList();
            foreach(var item in lista)
            {
                foreach(var lojas in produtoVM.LojaId)
                {
                    if(item.LojaId == lojas)
                    {
                        item.Check = true;
                    }
                }
            }

            ViewBag.Lojas = lista;
            return View(produtoVM);

        }
        [HttpPost]
        public IActionResult Editar(ProdutoLojaViewModel produtoVM)
        {
            var produtoModel = produtoVM.Produto;
            produtoModel.ProdutoLoja = new List<ProdutoLojaModel>();

            foreach (var lojas in produtoVM.LojaId)
            {
                var produtoLojaModel = new ProdutoLojaModel()
                {
                    LojaId = lojas,
                    Produto = produtoModel
                };
                produtoModel.ProdutoLoja.Add(produtoLojaModel);
            }

            _produtoRepository.Update(produtoModel);
            TempData["mensagemSucesso"] = $"Produto  editado com sucesso";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var lista = _lojaRepository.FindAll();
            ViewBag.Lojas = lista;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoLojaViewModel produtoVM)
        {
            var produtoModel = produtoVM.Produto;
            produtoModel.ProdutoLoja = new List<ProdutoLojaModel>();

            foreach(var lojas in produtoVM.LojaId)
            {
                var produtoLojaModel = new ProdutoLojaModel()
                {
                    LojaId = lojas,
                    Produto = produtoModel
                };
                produtoModel.ProdutoLoja.Add(produtoLojaModel);
            }

            _produtoRepository.Insert(produtoModel);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _produtoRepository.Delete(id);
            TempData["mensagemSucesso"] = "Produto excluido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
