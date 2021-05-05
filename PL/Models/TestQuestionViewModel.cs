using System.Collections.Generic;
using DAL.Entities;

namespace PL.Models
{
    /// <summary>
    /// Question view model.
    /// </summary>
    public class TestQuestionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuizGroupId { get; set; }
        public bool MultipleAnswer { get; set; }

        public virtual QuizGroup Quiz { get; set; }
        public virtual ICollection<TestAnswer> Answers { get; set; }
    }
}