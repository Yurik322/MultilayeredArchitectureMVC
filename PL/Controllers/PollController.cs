using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using PL.Models;

namespace PL.Controllers
{
    /// <summary>
    /// Controller for survey page.
    /// </summary>
    public class PollController : Controller
    {
        private readonly ITestAnswerService answerService;
        public PollController(ITestAnswerService serv)
        {
            answerService = serv;
        }

        public ActionResult Poll()
        {
            IEnumerable<TestQuestionDTO> testQuestionDtos = answerService.GetQuestions();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestQuestionDTO, TestQuestionViewModel>()).CreateMapper();
            var questions = mapper.Map<IEnumerable<TestQuestionDTO>, List<TestQuestionViewModel>>(testQuestionDtos);
            return View(questions);
        }

        [HttpPost]
        public ActionResult Poll(string name, string[] genres, string wantback = "Not choose")
        {
            ViewBag.Name = name;
            if (genres is null)
            {
                genres = new string[] { "No choose" };
                ViewBag.Genres = genres;
            }
            else
            {
                ViewBag.Genres = genres;
            }
            ViewBag.Back = wantback;
            return View("PollResult");
        }
    }
}