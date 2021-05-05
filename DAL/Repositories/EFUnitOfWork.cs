using System;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Unit of Work pattern simplifies working with different repositories for getting data from repository.
    /// It Helps work with data context.
    /// </summary>
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext db;
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private QuizGroupRepository quizGroupRepository;
        private TestQuestionRepository testQuestionRepository;
        private TestAnswerRepository testAnswerRepository;

        public EfUnitOfWork(string connectionString)
        {
            db = new LibraryContext(connectionString);
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<QuizGroup> QuizGroups
        {
            get
            {
                if (quizGroupRepository == null)
                    quizGroupRepository = new QuizGroupRepository(db);
                return quizGroupRepository;
            }
        }

        public IRepository<TestQuestion> TestQuestions
        {
            get
            {
                if (testQuestionRepository == null)
                    testQuestionRepository = new TestQuestionRepository(db);
                return testQuestionRepository;
            }
        }

        public IRepository<TestAnswer> TestAnswers
        {
            get
            {
                if (testAnswerRepository == null)
                    testAnswerRepository = new TestAnswerRepository(db);
                return testAnswerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
