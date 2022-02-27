using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository()
        {
            dataContext = new DataContext();
        }

        public List<ProdutoModel> FindAll()
        {
            return dataContext.Produto.ToList();
        }

        public ProdutoModel FindById(int id)
        {
            var produto = dataContext.Produto
                .Include(p => p.ProdutoLoja)
                .ThenInclude(l => l.Loja)
                .SingleOrDefault(p => p.ProdutoId == id);
            return produto;
        }
        public ProdutoLojaModel FindById2(int id)
        {
            return dataContext.ProdutoLoja.Find(id);
        }
        public void Insert(ProdutoModel produtoModel)
        {
            dataContext.Produto.Add(produtoModel);
            dataContext.SaveChanges();
        }

        public void Update(ProdutoModel produtoModel)
        {
            var produtoAtual = FindById(produtoModel.ProdutoId);
            produtoAtual.ProdutoNome = produtoModel.ProdutoNome;
            produtoAtual.ProdutoLoja = produtoModel.ProdutoLoja;

            dataContext.Update(produtoAtual);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = new ProdutoModel();
            produto.ProdutoId = id;
            dataContext.Produto.Remove(produto);
            dataContext.SaveChanges();
        }
    }
}
