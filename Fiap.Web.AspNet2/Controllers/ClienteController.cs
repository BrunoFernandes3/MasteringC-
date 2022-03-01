using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
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
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepresentanteRepository _representanteRepository;

        public ClienteController(IClienteRepository clienteRepository, IRepresentanteRepository representanteRepository)
        {
            _clienteRepository = clienteRepository;
            //representanteRepository = new RepresentanteRepository();
            _representanteRepository = representanteRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<ClienteModel> cliente = _clienteRepository.FindAll();
            Console.WriteLine("Validando acesso ao controller");
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            IList<RepresentanteModel> representantes = _representanteRepository.FindAll();
            ViewBag.Representantes = representantes;
            return View(new ClienteModel());
        }
        [HttpPost]
        public IActionResult Cadastrar(ClienteModel clienteModel)
        {
            _clienteRepository.Insert(clienteModel);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            IList<RepresentanteModel> representantes = _representanteRepository.FindAll();
            ViewBag.Representantes = representantes;
            ClienteModel clienteModel = _clienteRepository.FindById(id);
            return View(clienteModel);
        }
        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            _clienteRepository.Update(clienteModel);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} editado com sucesso.";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var clienteModel = _clienteRepository.FindById(id);
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} excluído com sucesso.";
            _clienteRepository.Delete(clienteModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = _clienteRepository.FindById(id);
            return View(clienteModel);
        }
    }
}
