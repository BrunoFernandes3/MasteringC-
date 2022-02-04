using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    public class RepresentanteModel
    {
        [Key]
        [HiddenInput]
        public int RepresentanteId { get; set; }
        [Display(Name =("Nome do Representante"))]
        public string NomeRepresentante { get; set; }

        public string Email { get; set; }
        [Display(Name = ("Data de Nascimento"))]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public IList<ClienteModel> Clientes { get; set; }

        public RepresentanteModel()
        {

        }

        public RepresentanteModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }

        public RepresentanteModel(int representanteId, string nomeRepresentante, string email, DateTime dataNascimento) : this(representanteId, nomeRepresentante)
        {
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}
