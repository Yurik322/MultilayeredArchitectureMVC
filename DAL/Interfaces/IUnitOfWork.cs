using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    /// <summary>
    /// Interface for getting lists from data context.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Comment> Comments { get; }
        IRepository<QuizGroup> QuizGroups { get; }
        IRepository<TestQuestion> TestQuestions { get; }
        IRepository<TestAnswer> TestAnswers { get; }
        void Save();
    }
}
