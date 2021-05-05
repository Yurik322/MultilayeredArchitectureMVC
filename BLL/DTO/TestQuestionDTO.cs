using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for question model.
    /// </summary>
    public class TestQuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuizGroupId { get; set; }
        public bool MultipleAnswer { get; set; }

        public virtual QuizGroup Quiz { get; set; }
        public virtual ICollection<TestAnswer> Answers { get; set; }
    }
}