using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Models
{
    public class ProdutoModel
    {
        [Key]
        [HiddenInput]
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }

        public ICollection<ProdutoLojaModel> ProdutoLoja{ get; set; }
    }
}
