using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Interface for getting methods from answer service.
    /// </summary>
    public interface ITestAnswerService
    {
        void AddAnswer(TestAnswerDTO testAnswerDto);
        IEnumerable<TestQuestionDTO> GetQuestions();
        IEnumerable<TestAnswerDTO> GetAnswers();
        TestQuestionDTO GetQuestion(int? id);
        void Dispose();
    }
}