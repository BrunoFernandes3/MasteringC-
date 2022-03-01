using AutoMapper;
using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Fiap.Web.AspNet2.Views.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("dataISUrl");
            services.AddDbContext<DataContext>(o => o.UseSqlServer(connectionString));

            var mapperConfig = new AutoMapper.MapperConfiguration
            (c =>
                {
                    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
                    c.CreateMap<ProdutoLojaViewModel, ProdutoModel>();
                    c.CreateMap<ClienteViewModel, ClienteModel>();
                    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();
                    c.CreateMap<ProdutoModel, ProdutoLojaViewModel>();
                    c.CreateMap<ClienteModel, ClienteViewModel>();

                }
            );

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cliente}/{action=Index}/{id?}");
            });
        }
    }
}
