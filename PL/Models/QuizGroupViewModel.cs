using System.Collections.Generic;
using BLL.DTO;

namespace PL.Models
{
    /// <summary>
    /// Quiz view model.
    /// </summary>
    public class QuizGroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TestQuestionDTO> Questions { get; set; }
    }
}