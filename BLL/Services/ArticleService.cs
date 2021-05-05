using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Class with article services.
    /// </summary>
    public class ArticleService : IArticleService
    {
        private IUnitOfWork Database { get; set; }

        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// Method for get all ArticleDTO objects.
        /// </summary>
        /// <returns>collection of ArticleDTO.</returns>
        public IEnumerable<ArticleDTO> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetAll());
        }

        /// <summary>
        /// Method for get ArticleDTO object by id.
        /// </summary>
        /// <param name="id">id of ArticleDTO.</param>
        public ArticleDTO GetArticle(int? id)
        {
            if (id == null)
                throw new ValidationException("Has not id in Article", "");
            var article = Database.Articles.Get(id.Value);
            if (article == null)
                throw new ValidationException("Article not found", "");

            return new ArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                Text = article.Text,
                Date = article.Date
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}