using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Models
{
    public class LojaModel
    {
        [Key]
        public int ProdutoId { get; set; }

        public string NomeProduto { get; set; }

        public ICollection<ProdutoLojaModel> ProdutoLoja { get; set; }
    }
}
