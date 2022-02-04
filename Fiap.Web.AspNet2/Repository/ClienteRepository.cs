using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository
    {
        //private readonly Object context;
        private readonly DataContext dataContext;

        public ClienteRepository()
        {
            dataContext = new DataContext();
        }

        public IList<ClienteModel> FindAll()
        {
            Console.WriteLine("Validando acesso ao FindAll()");
            return dataContext.Cliente.ToList(); ;
        }

        public ClienteModel FindById(int id)
        {
            var clienteModel = dataContext.Cliente
                .Include(c => c.Representante)
                .SingleOrDefault(c => c.ClienteId == id);

            return clienteModel;
        }

        public void Insert(ClienteModel clienteModel)
        {
            Console.WriteLine("Validando acesso ao Insert()");

            dataContext.Cliente.Add(clienteModel);
            dataContext.SaveChanges();
        }

        public void Delete(ClienteModel clienteModel)
        {
            dataContext.Cliente.Remove(clienteModel);
            dataContext.SaveChanges();
        }


        public void Update(ClienteModel clienteModel)
        {
            dataContext.Update(clienteModel);
            dataContext.SaveChanges();
        }
    }
}
