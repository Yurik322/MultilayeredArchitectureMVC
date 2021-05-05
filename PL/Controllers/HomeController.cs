using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using PL.Models;

namespace PL.Controllers
{
    /// <summary>
    /// Controller for main page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        public HomeController(IArticleService serv)
        {
            articleService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<ArticleDTO> articleDtos = articleService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            return View(articles);
        }
    }
}