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
    public class GuestControllerTest
    {
        [TestMethod]
        public void GuestViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<ICommentService>();
            mock.Setup(a => a.GetComments()).Returns(new List<CommentDTO>());
            GuestController controller = new GuestController(mock.Object);

            // Act
            ViewResult result = controller.Guest() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void AddNewComment_ModelError()
        {
            // arrange
            string expected = "";
            var mock = new Mock<ICommentService>();
            string name = "name";
            string text = "text";
            GuestController controller = new GuestController(mock.Object);
            // act
            ViewResult result = controller.Guest(name, text) as ViewResult;
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }
    }
}
