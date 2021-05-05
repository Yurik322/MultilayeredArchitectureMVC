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
    /// Class repository for work with quizzes.
    /// </summary>
    public class QuizGroupRepository : IRepository<QuizGroup>
    {
        private readonly LibraryContext db;

        public QuizGroupRepository(LibraryContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Method for get all quizzes from db.
        /// </summary>
        /// <returns>list of all quizzes.</returns>
        public IEnumerable<QuizGroup> GetAll()
        {
            return db.QuizGroups;
        }

        /// <summary>
        /// Method for get quiz by id from db.
        /// </summary>
        /// <param name="id">id of quiz.</param>
        /// <returns>get quiz.</returns>
        public QuizGroup Get(int id)
        {
            return db.QuizGroups.Find(id);
        }

        /// <summary>
        /// Method for create quiz in db.
        /// </summary>
        /// <param name="item">new quiz.</param>
        public void Create(QuizGroup item)
        {
            db.QuizGroups.Add(item);
        }

        /// <summary>
        /// Method for update quiz in db.
        /// </summary>
        /// <param name="item">updated quiz.</param>
        public void Update(QuizGroup item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for searching quiz in db.
        /// </summary>
        /// <param name="predicate">predicate quiz.</param>
        /// <returns>get quiz.</returns>
        public IEnumerable<QuizGroup> Find(Func<QuizGroup, Boolean> predicate)
        {
            return db.QuizGroups.Where(predicate).ToList();
        }

        /// <summary>
        /// Method for deleting quiz from db.
        /// </summary>
        /// <param name="id">id of quiz.</param>
        public void Delete(int id)
        {
            QuizGroup quizGroup = db.QuizGroups.Find(id);
            if (quizGroup != null)
                db.QuizGroups.Remove(quizGroup);
        }
    }
}
