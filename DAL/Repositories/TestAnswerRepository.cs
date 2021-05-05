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
    /// Class repository for work with answers.
    /// </summary>
    public class TestAnswerRepository : IRepository<TestAnswer>
    {
        private readonly LibraryContext db;

        public TestAnswerRepository(LibraryContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Method for get all answers from db.
        /// </summary>
        /// <returns>list of all answers.</returns>
        public IEnumerable<TestAnswer> GetAll()
        {
            return db.TestAnswers;
        }

        /// <summary>
        /// Method for get answer by id from db.
        /// </summary>
        /// <param name="id">id of answer.</param>
        /// <returns>get answer.</returns>
        public TestAnswer Get(int id)
        {
            return db.TestAnswers.Find(id);
        }

        /// <summary>
        /// Method for create answer in db.
        /// </summary>
        /// <param name="item">new answer.</param>
        public void Create(TestAnswer item)
        {
            db.TestAnswers.Add(item);
        }

        /// <summary>
        /// Method for update answer in db.
        /// </summary>
        /// <param name="item">updated answer.</param>
        public void Update(TestAnswer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Method for searching answer in db.
        /// </summary>
        /// <param name="predicate">predicate answer.</param>
        /// <returns>get answer.</returns>
        public IEnumerable<TestAnswer> Find(Func<TestAnswer, Boolean> predicate)
        {
            return db.TestAnswers.Where(predicate).ToList();
        }

        /// <summary>
        /// Method for deleting answer from db.
        /// </summary>
        /// <param name="id">id of answer.</param>
        public void Delete(int id)
        {
            TestAnswer testAnswer = db.TestAnswers.Find(id);
            if (testAnswer != null)
                db.TestAnswers.Remove(testAnswer);
        }
    }
}
