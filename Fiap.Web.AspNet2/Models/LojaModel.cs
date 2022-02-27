using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    public class LojaModel
    {
        [Key]
        [HiddenInput]
        public int LojaId { get; set; }

        public string LojaNome { get; set; }
        [NotMapped]
        public bool Check { get; set; }

        public ICollection<ProdutoLojaModel> ProdutoLoja { get; set; }
    }
}
