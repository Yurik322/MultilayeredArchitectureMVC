using System.Collections.Generic;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PL.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<IArticleService>();
            mock.Setup(a => a.GetArticles()).Returns(new List<ArticleDTO>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
