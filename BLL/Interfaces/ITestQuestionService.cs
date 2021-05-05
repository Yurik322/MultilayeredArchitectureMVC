using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Interface for getting methods from question service.
    /// </summary>
    public interface ITestQuestionService
    {
        void AddTestQuestion(TestQuestionDTO testQuestionDto);
        IEnumerable<QuizGroupDTO> GetQuizzes();
        QuizGroupDTO GetQuiz(int? id);
        void Dispose();
    }
}