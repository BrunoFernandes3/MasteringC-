using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Views.ViewModel
{
    public class ProdutoLojaViewModel
    {
        public ProdutoModel Produto { get; set; }
        public ICollection<int> LojaId { get; set; }
    }
}
