using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository 
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<ProdutoModel> FindAll()
        {
            return _dataContext.Produto.ToList();
        }

        public ProdutoModel FindById(int id)
        {
            var produto = _dataContext.Produto
                .Include(p => p.ProdutoLoja)
                .ThenInclude(l => l.Loja)
                .SingleOrDefault(p => p.ProdutoId == id);
            return produto;
        }
        public ProdutoLojaModel FindById2(int id)
        {
            return _dataContext.ProdutoLoja.Find(id);
        }
        public void Insert(ProdutoModel produtoModel)
        {
            _dataContext.Produto.Add(produtoModel);
            _dataContext.SaveChanges();
        }

        public void Update(ProdutoModel produtoModel)
        {
            var produtoAtual = FindById(produtoModel.ProdutoId);
            produtoAtual.ProdutoNome = produtoModel.ProdutoNome;
            produtoAtual.ProdutoLoja = produtoModel.ProdutoLoja;

            _dataContext.Update(produtoAtual);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = new ProdutoModel();
            produto.ProdutoId = id;
            _dataContext.Produto.Remove(produto);
            _dataContext.SaveChanges();
        }
    }
}
