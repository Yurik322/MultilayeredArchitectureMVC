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
    public class PollControllerTest
    {
        [TestMethod]
        public void PollViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<ITestAnswerService>();
            mock.Setup(a => a.GetQuestions()).Returns(new List<TestQuestionDTO>());
            PollController controller = new PollController(mock.Object);

            // Act
            ViewResult result = controller.Poll() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // arrange
            string expected = "PollResult";
            var mock = new Mock<ITestAnswerService>();
            //Computer comp = new Computer();
            string name = "Bob";
            string[] genres = new []{ "Detective", "Fantasy", "Novels" };
            string wantback = "Yes!";
            PollController controller = new PollController(mock.Object);
            // act
            ViewResult result = controller.Poll(name, genres, wantback) as ViewResult;
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }
    }
}
