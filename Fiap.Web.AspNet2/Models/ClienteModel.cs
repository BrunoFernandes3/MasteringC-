using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    public class ClienteModel
    {
        [Display(Name ="Id do Cliente")]
        [HiddenInput]
        [Key]
        [Required]
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

        public int RepresentanteId { get; set; }

        [ForeignKey("RepresentanteId")]
        public RepresentanteModel RepresentanteModel { get; set; }

        public ClienteModel()
        {

        }

        public ClienteModel(int clienteId, string nome, string email)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
        }

        public ClienteModel(int clienteId,string nome, string email, DateTime dataNascimento, string observacao)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Observacao = observacao;
        }

        public ClienteModel(int clienteId, string nome, string email, DateTime dataNascimento, string observacao, int representanteId) : this(clienteId, nome, email, dataNascimento, observacao)
        {
            RepresentanteId = representanteId;
        }
    }
}
