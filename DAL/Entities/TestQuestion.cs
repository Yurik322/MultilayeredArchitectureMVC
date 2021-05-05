using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// TestQuestion entity model.
    /// </summary>
    public class TestQuestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuizGroupId { get; set; }
        public bool MultipleAnswer { get; set; }
        public virtual QuizGroup Quiz { get; set; }
        public virtual ICollection<TestAnswer> Answers { get; set; }
    }
}
