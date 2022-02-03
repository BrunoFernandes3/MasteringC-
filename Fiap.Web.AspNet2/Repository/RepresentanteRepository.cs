using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository
    {
        private readonly DataContext context;
        public RepresentanteRepository()
        {
            context = new DataContext();
        }

        public IList<RepresentanteModel> FindAll()
        {
            //Exemplo de LINQ
            //var lista = context.Representante.Where(r => r.NomeRepresentante.Contains("a")).ToList();
            //
            //var lista = context.Representante.Where(r => r.RepresentanteId == 1).ToList(); 
            //Operadores Lógicos podem ser utilizados junto com o LINQ

            return context.Representante.ToList();
        }

        public RepresentanteModel FindById(int id)
        {
            return context.Representante.Find(id);
        }

        public void Insert(RepresentanteModel representanteModel)
        {
            context.Representante.Add(representanteModel);
            context.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            context.Representante.Update(representanteModel);
            context.SaveChanges();
        }

        public void Delete(RepresentanteModel representanteModel)
        {
            context.Representante.Remove(representanteModel);
            context.SaveChanges();
        }

        public void  Delete (int id)
        {
            var representanteModel = new RepresentanteModel();
            representanteModel.RepresentanteId = id;
            Delete(representanteModel);
        }
    }
}
