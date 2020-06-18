using AspNetCoreWebApplication.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.IO;
using System;

namespace AspNetCoreWebApplicationTest.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = (ViewResult)controller.Index();
            /*Assert.Single(result.ViewData);   */        
        }

        [Fact]
        public void ErrorTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = (ViewResult)controller.Error();
            Assert.Single(result.ViewData);
            Assert.Equal("We've encountered an error :(", result.ViewData["Message"]);
        }

        [Fact]
        public void SubmitTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = (ViewResult)controller.Error();
            Assert.Single(result.ViewData);          
        }
    }
}