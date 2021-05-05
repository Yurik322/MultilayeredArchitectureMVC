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
    /// Class repository for work with comments.
    /// </summary>
    public class CommentRepository : IRepository<Comment>
    {
        private readonly LibraryContext db;

        public CommentRepository(LibraryContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Method for get all comments from db.
        /// </summary>
        /// <returns>list of all comments.</returns>
        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        /// <summary>
        /// Method for get comment by id from db.
        /// </summary>
        /// <param name="id">id of comment.</param>
        /// <returns>get comment.</returns>
        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        /// <summary>
        /// Method for create comment in db.
        /// </summary>
        /// <param name="item">new comment.</param>
        public void Create(Comment item)
        {
            db.Comments.Add(item);
        }

        /// <summary>
        /// Method for update comment in db.
        /// </summary>
        /// <param name="item">updated comment.</param>
        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for searching comment in db.
        /// </summary>
        /// <param name="predicate">predicate comment.</param>
        /// <returns>get comment.</returns>
        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }

        /// <summary>
        /// Method for deleting comment from db.
        /// </summary>
        /// <param name="id">id of comment.</param>
        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }
    }
}
