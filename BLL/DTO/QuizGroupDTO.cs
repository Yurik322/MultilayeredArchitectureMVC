using System.Collections.Generic;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for quiz model.
    /// </summary>
    public class QuizGroupDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TestQuestionDTO> Questions { get; set; }
    }
}