using AutoMapper;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteRepository _representanteRepository;
        private readonly IMapper _mapper;

        public RepresentanteController(IRepresentanteRepository representanteRepository, IMapper mapper)
        {
            _representanteRepository = representanteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var representante = _representanteRepository.FindAll();

            //representanteVM.Representantes = _representanteRepository.FindAll()
            //.Select(item => new RepresentanteViewModel(item.RepresentanteId, item.NomeRepresentante, item.Email, item.DataNascimento))
            //.ToList();
            

            var representanteVM = _mapper.Map<IList<RepresentanteViewModel>>(_representanteRepository.FindAll());

            return View(representanteVM);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new RepresentanteViewModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(RepresentanteViewModel representanteVM)
        {
            //var representanteModel = new RepresentanteModel();
            //representanteModel.RepresentanteId = representanteVM.RepresentanteId;
            //representanteModel.NomeRepresentante = representanteVM.NomeRepresentante;
            //representanteModel.Email = representanteVM.Email;
            //representanteModel.DataNascimento = representanteVM.DataNascimento;

            var representanteModel = _mapper.Map<RepresentanteModel>(representanteVM);

            _representanteRepository.Insert(representanteModel);
            TempData["mensagemSucesso"] = $"Representante {representanteVM.NomeRepresentante} cadastrado com sucesso";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var representante = _representanteRepository.FindByIdWithClientes(id);
            var representanteVM = _mapper.Map<RepresentanteViewModel>(representante);

            return View(representanteVM);

        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var representante = _representanteRepository.FindById(id);
            TempData["mensagemSucesso"] = $"Representante {representante.NomeRepresentante} excluido com sucesso";
            _representanteRepository.Delete(representante);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var representante = _representanteRepository.FindById(id);

            var representanteVM = _mapper.Map<RepresentanteViewModel>(representante);

            return View(representanteVM);
        }

        [HttpPost]
        public IActionResult Editar(RepresentanteViewModel representanteVM)
        {
            //Utilizando automapper para ligar a viewmodel a model
            var representanteModel = _mapper.Map<RepresentanteModel>(representanteVM);

            _representanteRepository.Update(representanteModel);
            TempData["mensagemSucesso"] = $"Representante {representanteVM.NomeRepresentante} editado com sucesso";
            return RedirectToAction("Index");
        }
    }
}
