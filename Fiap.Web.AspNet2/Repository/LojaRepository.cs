using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class LojaRepository
    {
        private readonly DataContext dataContext;

        public LojaRepository()
        {
           dataContext = new DataContext();
        }

        public List<LojaModel> FindAll()
        {
            return dataContext.Loja.ToList();
        }
        
        public LojaModel FindById(int id)
        {
            var loja = dataContext.Loja
                .Include(l => l.ProdutoLoja)
                .ThenInclude(p => p.Produto)
                .SingleOrDefault(l => l.LojaId == id);
            return loja ;
        }

        public void Insert(LojaModel lojaModel)
        {
            dataContext.Loja.Add(lojaModel);
            dataContext.SaveChanges();
        }

        public void Update(LojaModel lojaModel)
        {
            dataContext.Loja.Update(lojaModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id) 
        {
            var loja = FindById(id);
            dataContext.Loja.Remove(loja);
            dataContext.SaveChanges();
        }
    }
}
