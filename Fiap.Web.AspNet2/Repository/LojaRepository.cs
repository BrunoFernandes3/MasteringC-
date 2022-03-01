using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext _dataContext;

        public LojaRepository(DataContext dataContext)
        {
           _dataContext = dataContext;
        }

        public List<LojaModel> FindAll()
        {
            return _dataContext.Loja.ToList();
        }
        
        public LojaModel FindById(int id)
        {
            var loja = _dataContext.Loja
                .Include(l => l.ProdutoLoja)
                .ThenInclude(p => p.Produto)
                .SingleOrDefault(l => l.LojaId == id);
            return loja ;
        }

        public void Insert(LojaModel lojaModel)
        {
            _dataContext.Loja.Add(lojaModel);
            _dataContext.SaveChanges();
        }

        public void Update(LojaModel lojaModel)
        {
            _dataContext.Loja.Update(lojaModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id) 
        {
            var loja = FindById(id);
            _dataContext.Loja.Remove(loja);
            _dataContext.SaveChanges();
        }
    }
}
