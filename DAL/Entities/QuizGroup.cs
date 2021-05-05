using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// QuizGroup entity model.
    /// </summary>
    public class QuizGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
