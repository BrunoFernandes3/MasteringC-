using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> FindAll();

        ProdutoModel FindById(int id);
        ProdutoLojaModel FindById2(int id);

        void Insert(ProdutoModel produtoModel);
        
        void Update(ProdutoModel produtoModel);
        
        void Delete(int id);

    }
}
