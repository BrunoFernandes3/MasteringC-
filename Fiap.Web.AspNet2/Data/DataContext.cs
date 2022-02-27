using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Fiap.Web.AspNet2.Data
{
    public class DataContext : DbContext
    {

        public DbSet<RepresentanteModel> Representante { get; set; }

        public DbSet<CidadeModel> Cidade { get; set; } 

        public DbSet<ClienteModel> Cliente { get; set; }

        public DbSet<LojaModel> Loja { get; set; }

        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<ProdutoLojaModel> ProdutoLoja  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                var config = new ConfigurationBuilder().
                    SetBasePath(Directory.GetCurrentDirectory()).
                    AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("dataISUrl")); // Importante, ele que faz a conexão
                optionsBuilder.EnableSensitiveDataLogging(); // LOG
                optionsBuilder.LogTo(Console.Write); // LOG
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CidadeModel>().HasData( // Insere dados na tabela, caso não existam.
                new CidadeModel()
                {
                    CidadeId = 1,
                    CidadeNome = "São Paulo",
                    QuantidadeHabitantes = 11
                }
                );
            new CidadeModel()
            {
                CidadeId = 2,
                CidadeNome = "Rio de Janeiro",
                QuantidadeHabitantes = 5
            };

            base.OnModelCreating(modelBuilder);
        }
    }
}
