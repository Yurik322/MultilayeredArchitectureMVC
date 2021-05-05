using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Class with question services.
    /// </summary>
    public class TestQuestionService : ITestQuestionService
    {
        private IUnitOfWork Database { get; set; }

        public TestQuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// Method for create new TestQuestionDTO object.
        /// </summary>
        /// <param name="testQuestionDto">TestQuestionDTO object.</param>
        /// <returns>new TestQuestionDTO object.</returns>
        public void AddTestQuestion(TestQuestionDTO testQuestionDto)
        {
            QuizGroup quizGroup = Database.QuizGroups.Get(testQuestionDto.QuizGroupId);

            if (quizGroup == null)
                throw new ValidationException("Quiz not found", "");
            TestQuestion testQuestion = new TestQuestion
            {
                Name = testQuestionDto.Name,
                QuizGroupId = quizGroup.Id,
                MultipleAnswer = testQuestionDto.MultipleAnswer
            };
            Database.TestQuestions.Create(testQuestion);
            Database.Save();
        }

        /// <summary>
        /// Method for get all QuizGroupDTO objects.
        /// </summary>
        /// <returns>collection of QuizGroupDTO.</returns>
        public IEnumerable<QuizGroupDTO> GetQuizzes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuizGroup, QuizGroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<QuizGroup>, List<QuizGroupDTO>>(Database.QuizGroups.GetAll());
        }

        /// <summary>
        /// Method for get QuizGroupDTO object by id.
        /// </summary>
        /// <param name="id">id of QuizGroupDTO.</param>
        /// <returns>QuizGroupDTO object.</returns>
        public QuizGroupDTO GetQuiz(int? id)
        {
            if (id == null)
                throw new ValidationException("Has not id in Quiz", "");
            var quiz = Database.QuizGroups.Get(id.Value);
            if (quiz == null)
                throw new ValidationException("Quiz not found", "");

            return new QuizGroupDTO
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Name = quiz.Name
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
