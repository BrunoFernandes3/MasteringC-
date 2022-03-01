using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interfaces
{
    public interface ILojaRepository
    {
        List<LojaModel> FindAll();


        LojaModel FindById(int id);
        

        void Insert(LojaModel lojaModel);
        

        void Update(LojaModel lojaModel);
       

        void Delete(int id); 
    }
}
