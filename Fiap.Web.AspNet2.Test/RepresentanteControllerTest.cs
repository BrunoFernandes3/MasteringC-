using Fiap.Web.AspNet2.Controllers;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fiap.Web.AspNet2.Test
{
    public class RepresentanteControllerTest
    {
        //Lista de representantes
        [Fact]
        public Task IndexReturnsViewResultWithListOfRepresentantes()
        {
            var representanteRepository = new Mock<IRepresentanteRepository>();
            representanteRepository.Setup(r => r.FindAll()).Returns(Lista());

            var representanteController = new RepresentanteController(representanteRepository.Object);

            var result = representanteController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Equal(3, model.Count());

            return Task.CompletedTask;
        }

        //Lista sem representantes
        [Fact]
        public Task IndexReturnsViewResultWithZeroRepresentantes()
        {
            var representanteRepository = new Mock<IRepresentanteRepository>();
            representanteRepository.Setup(r => r.FindAll()).Returns(new List<RepresentanteModel>());

            var representanteController = new RepresentanteController(representanteRepository.Object);

            var result = representanteController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Empty(model);

            return Task.CompletedTask;
        }

        private IList<RepresentanteModel> Lista()
        {
            return new List<RepresentanteModel>
            {
                new RepresentanteModel(1,"Bruno"),
                new RepresentanteModel(2,"Sophia"),
                new RepresentanteModel(3,"Ayla")
            };
        }

        //Lista com 1 representante

        //Lista  com exception

    }
}
