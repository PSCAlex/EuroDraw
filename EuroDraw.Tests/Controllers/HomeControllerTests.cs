using EuroDraw.Controllers;
using EuroDraw.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Xunit;

namespace EuroDraw.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResut()
        {
            var controller = new HomeController(new DrawRepo());

            Assert.IsType<ViewResult>(controller.Index());
        }

        [Fact]
        public void DrawReturnsDrawViewModel()
        {
            var controller = new HomeController(new DrawRepo());

            var result = Assert.IsType<ViewResult>(controller.Draw());

            var model = Assert.IsAssignableFrom<DrawViewModel>(result.ViewData.Model);
        }

        [Fact]
        public void DrawReturnsCountryListOfCorrectLength()
        {
            var controller = new HomeController(new DrawRepo());

            var result = controller.Draw() as ViewResult;

            var model = result.Model as DrawViewModel;

            Assert.Equal(24, model.countries.Count());
        }

        [Fact]
        public void DrawReturnsPeopleListOfCorrectLength()
        {
            var controller = new HomeController(new DrawRepo());

            var result = controller.Draw() as ViewResult;

            var model = result.Model as DrawViewModel;

            Assert.Equal(24, model.people.Count());
        }

        [Fact]
        public void ErrorReturnsViewResult()
        {
            var controller = new HomeController(new DrawRepo());

            var result = Assert.IsType<ViewResult>(controller.Error());

            var bag = Assert.IsAssignableFrom<DateTime>(result.ViewData["Time"]);
        }

    }
}
