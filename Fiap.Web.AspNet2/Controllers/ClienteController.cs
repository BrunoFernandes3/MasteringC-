using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController()
        {
            clienteRepository = new ClienteRepository();   
            representanteRepository = new RepresentanteRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<ClienteModel> cliente = clienteRepository.FindAll();
            Console.WriteLine("Validando acesso ao controller");
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            IList<RepresentanteModel> representantes = representanteRepository.FindAll();
            ViewBag.Representantes = representantes;
            return View(new ClienteModel());
        }
        [HttpPost]
        public IActionResult Cadastrar(ClienteModel clienteModel)
        {
            clienteRepository.Insert(clienteModel);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            IList<RepresentanteModel> representantes = representanteRepository.FindAll();
            ViewBag.Representantes = representantes;
            ClienteModel clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
        }
        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            clienteRepository.Update(clienteModel);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} editado com sucesso.";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} excluído com sucesso.";
            clienteRepository.Delete(clienteModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
        }
    }
}
