using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Class repository for work with articles.
    /// </summary>
    public class ArticleRepository : IRepository<Article>
    {
        private readonly LibraryContext db;

        public ArticleRepository(LibraryContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Method for get all articles from db.
        /// </summary>
        /// <returns>list of all articles.</returns>
        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        /// <summary>
        /// Method for get article by id from db.
        /// </summary>
        /// <param name="id">id of article.</param>
        /// <returns>get article.</returns>
        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        /// <summary>
        /// Method for create article in db.
        /// </summary>
        /// <param name="item">new article.</param>
        public void Create(Article item)
        {
            db.Articles.Add(item);
        }

        /// <summary>
        /// Method for update article in db.
        /// </summary>
        /// <param name="item">updated article.</param>
        public void Update(Article item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for searching article in db.
        /// </summary>
        /// <param name="predicate">predicate article.</param>
        /// <returns>get article.</returns>
        public IEnumerable<Article> Find(Func<Article, Boolean> predicate)
        {
            return db.Articles.Where(predicate).ToList();
        }

        /// <summary>
        /// Method for deleting article from db.
        /// </summary>
        /// <param name="id">id of article.</param>
        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
                db.Articles.Remove(article);
        }
    }
}
