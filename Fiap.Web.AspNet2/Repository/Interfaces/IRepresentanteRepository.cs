using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interfaces
{
    public interface IRepresentanteRepository
    {
        IList<RepresentanteModel> FindAll();
        RepresentanteModel FindById(int id);
        RepresentanteModel FindByIdWithClientes(int id);
        void Insert(RepresentanteModel representanteModel);
        void Update(RepresentanteModel representanteModel);

        void Delete(RepresentanteModel representanteModel);
        void Delete(int id);

    }
}
