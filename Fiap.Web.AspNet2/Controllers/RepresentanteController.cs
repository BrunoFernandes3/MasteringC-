using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly RepresentanteRepository representanteRepository;

        public RepresentanteController()
        {
            representanteRepository = new RepresentanteRepository();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var representante = representanteRepository.FindAll();
            return View(representante);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new RepresentanteModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(RepresentanteModel representanteModel)
        {
            representanteRepository.Insert(representanteModel);
            TempData["mensagemSucesso"] = $"Representante {representanteModel.NomeRepresentante} cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var representante = representanteRepository.FindById(id);
            return View(representante);

        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var representante = representanteRepository.FindById(id);
            TempData["mensagemSucesso"] = $"Representante {representante.NomeRepresentante} excluido com sucesso";
            representanteRepository.Delete(representante);

            return RedirectToAction("Index");
        }

       [HttpGet]
       public IActionResult Editar(int id)
        {
           var representante = representanteRepository.FindById(id);
           return View(representante);
        }

        [HttpPost]
        public IActionResult Editar(RepresentanteModel representanteModel)
        {
            representanteRepository.Update(representanteModel);
            TempData["mensagemSucesso"] = $"Representante {representanteModel.NomeRepresentante} editado com sucesso";
            return RedirectToAction("Index");
        }
    }
}
