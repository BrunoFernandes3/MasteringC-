using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interfaces
{
    public interface IClienteRepository
    {
        IList<ClienteModel> FindAll();


        ClienteModel FindById(int id);


        void Insert(ClienteModel clienteModel);
      

        void Delete(ClienteModel clienteModel);


        void Update(ClienteModel clienteModel);

    }
}
