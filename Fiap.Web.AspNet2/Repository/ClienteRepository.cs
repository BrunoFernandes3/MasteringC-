using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //private readonly Object context;
        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<ClienteModel> FindAll()
        {
            Console.WriteLine("Validando acesso ao FindAll()");
            return _dataContext.Cliente.ToList(); 
        }

        public ClienteModel FindById(int id)
        {
            var clienteModel = _dataContext.Cliente
                .Include(c => c.Representante)
                .SingleOrDefault(c => c.ClienteId == id);

            return clienteModel;
        }

        public void Insert(ClienteModel clienteModel)
        {
            Console.WriteLine("Validando acesso ao Insert()");

            _dataContext.Cliente.Add(clienteModel);
            _dataContext.SaveChanges();
        }

        public void Delete(ClienteModel clienteModel)
        {
            _dataContext.Cliente.Remove(clienteModel);
            _dataContext.SaveChanges();
        }


        public void Update(ClienteModel clienteModel)
        {
            _dataContext.Update(clienteModel);
            _dataContext.SaveChanges();
        }
    }
}
