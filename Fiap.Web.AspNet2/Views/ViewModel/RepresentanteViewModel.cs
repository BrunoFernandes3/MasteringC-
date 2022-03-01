using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Views.ViewModel
{
    public class RepresentanteViewModel
    {
        [HiddenInput]
        public int RepresentanteId { get; set; }
        [Display(Name = ("Nome do Representante"))]
        public string NomeRepresentante { get; set; }
        public string Email { get; set; }
        [Display(Name = ("Data de Nascimento"))]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public IList<RepresentanteViewModel> Representantes { get; set; }

        public IList<ClienteViewModel> Clientes { get; set; }

        public RepresentanteViewModel()
        {

        }

        public RepresentanteViewModel(int representanteId, string nomeRepresentante, string email, DateTime dataNascimento)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }

    
}
