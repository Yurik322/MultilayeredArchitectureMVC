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
    /// Class with answer services.
    /// </summary>
    public class TestAnswerService : ITestAnswerService
    {
        private IUnitOfWork Database { get; set; }

        public TestAnswerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// Method for create new TestAnswerDTO object.
        /// </summary>
        /// <param name="testAnswerDto">TestAnswerDTO object.</param>
        /// <returns>new TestAnswerDTO object.</returns>
        public void AddAnswer(TestAnswerDTO testAnswerDto)
        {
            TestQuestion testQuestion = Database.TestQuestions.Get(testAnswerDto.TestQuestionId);

            if (testQuestion == null)
                throw new ValidationException("Answer not found", "");
            TestAnswer testAnswer = new TestAnswer
            {
                Name = testAnswerDto.Name,
                TestQuestionId = testQuestion.Id
            };
            Database.TestAnswers.Create(testAnswer);
            Database.Save();
        }

        /// <summary>
        /// Method for get all TestAnswerDTO objects.
        /// </summary>
        /// <returns>collection of TestAnswerDTO.</returns>
        public IEnumerable<TestAnswerDTO> GetAnswers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestAnswer, TestAnswerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TestAnswer>, List<TestAnswerDTO>>(Database.TestAnswers.GetAll());
        }

        /// <summary>
        /// Method for get all TestQuestionDTO objects.
        /// </summary>
        /// <returns>collection of TestQuestionDTO.</returns>
        public IEnumerable<TestQuestionDTO> GetQuestions()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestQuestion, TestQuestionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TestQuestion>, List<TestQuestionDTO>>(Database.TestQuestions.GetAll());
        }

        /// <summary>
        /// Method for get TestQuestionDTO object by id.
        /// </summary>
        /// <param name="id">id of TestQuestionDTO.</param>
        /// <returns>TestQuestionDTO object.</returns>
        public TestQuestionDTO GetQuestion(int? id)
        {
            if (id == null)
                throw new ValidationException("Has not id in Question", "");
            var testQuestion = Database.TestQuestions.Get(id.Value);
            if (testQuestion == null)
                throw new ValidationException("Question not found", "");

            return new TestQuestionDTO()
            {
                Id = testQuestion.Id,
                Name = testQuestion.Name,
                QuizGroupId = testQuestion.QuizGroupId,
                MultipleAnswer = testQuestion.MultipleAnswer
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
