using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Models
{
    public class ProdutoModel
    {
        [Key]
        public int LojaId { get; set; }
        public string NomeLoja { get; set; }

        public ICollection<ProdutoLojaModel> ProdutoLoja{ get; set; }
    }
}
