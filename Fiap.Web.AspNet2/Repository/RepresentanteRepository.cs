using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository : IRepresentanteRepository
    {
        private readonly DataContext _context;
        public RepresentanteRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IList<RepresentanteModel> FindAll()
        {
            //Exemplo de LINQ
            //var lista = context.Representante.Where(r => r.NomeRepresentante.Contains("a")).ToList();
            //
            //var lista = context.Representante.Where(r => r.RepresentanteId == 1).ToList(); 
            //Operadores Lógicos podem ser utilizados junto com o LINQ

            return _context.Representante.ToList();
        }
 
        public RepresentanteModel FindById(int id)
        {
            return _context.Representante.Find(id);
        }

        public RepresentanteModel FindByIdWithClientes(int id)
        {
            return _context.Representante
                .Include(r => r.Clientes)
                .SingleOrDefault(r => r.RepresentanteId == id);
        }

        public void Insert(RepresentanteModel representanteModel)
        {
            _context.Representante.Add(representanteModel);
            _context.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            _context.Representante.Update(representanteModel);
            _context.SaveChanges();
        }

        public void Delete(RepresentanteModel representanteModel)
        {
            _context.Representante.Remove(representanteModel);
            _context.SaveChanges();
        }

        public void  Delete (int id)
        {
            var representanteModel = new RepresentanteModel();
            representanteModel.RepresentanteId = id;
            Delete(representanteModel);
        }
    }
}
