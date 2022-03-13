using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Views.ViewModel
{
    public class FornecedorViewModel
    {
        [HiddenInput]
        public int FornecedorId { get; set; }
        [Display(Name ="CNPJ: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="O campo CNPJ é obrigatório")]
        public string CNPJ { get; set; }
        [Display(Name ="Razão Social: ")]
        [Required(AllowEmptyStrings = true, ErrorMessage ="O campo Razão Social é obrigatório")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Telefone (XX) XXXXX-XXXX: ")]
        [Required(AllowEmptyStrings = true, ErrorMessage ="O campo Telefone é obrigatório")]
        public string Telefone { get; set; }
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Display(Name = "Data de Abertura: ")]
        public DateTime DataAbertura { get; set; }
        [Display(Name = "Capital Social R$: ")]
        public double ValorCapitalSocial { get; set; }
        [Display(Name = "Quantidade de Funcionarios: ")]
        public int QuantidadeFuncionarios { get; set; }

    }
}
