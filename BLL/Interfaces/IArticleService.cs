using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Interface for getting methods from article service.
    /// </summary>
    public interface IArticleService
    {
        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticle(int? id);
        void Dispose();
    }
}