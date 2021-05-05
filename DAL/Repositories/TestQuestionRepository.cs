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
    /// Class repository for work with questions.
    /// </summary>
    public class TestQuestionRepository : IRepository<TestQuestion>
    {
        private readonly LibraryContext db;

        public TestQuestionRepository(LibraryContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Method for get all questions from db.
        /// </summary>
        /// <returns>list of all questions.</returns>
        public IEnumerable<TestQuestion> GetAll()
        {
            return db.TestQuestions;
        }

        /// <summary>
        /// Method for get question by id from db.
        /// </summary>
        /// <param name="id">id of question.</param>
        /// <returns>get question.</returns>
        public TestQuestion Get(int id)
        {
            return db.TestQuestions.Find(id);
        }

        /// <summary>
        /// Method for create question in db.
        /// </summary>
        /// <param name="item">new question.</param>
        public void Create(TestQuestion item)
        {
            db.TestQuestions.Add(item);
        }

        /// <summary>
        /// Method for update question in db.
        /// </summary>
        /// <param name="item">updated question.</param>
        public void Update(TestQuestion item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for searching question in db.
        /// </summary>
        /// <param name="predicate">predicate question.</param>
        /// <returns>get question.</returns>
        public IEnumerable<TestQuestion> Find(Func<TestQuestion, Boolean> predicate)
        {
            return db.TestQuestions.Where(predicate).ToList();
        }

        /// <summary>
        /// Method for deleting question from db.
        /// </summary>
        /// <param name="id">id of question.</param>
        public void Delete(int id)
        {
            TestQuestion testQuestion = db.TestQuestions.Find(id);
            if (testQuestion != null)
                db.TestQuestions.Remove(testQuestion);
        }
    }
}
