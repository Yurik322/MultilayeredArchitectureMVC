using DAL.Entities;

namespace PL.Models
{
    /// <summary>
    /// Answer view model.
    /// </summary>
    public class TestAnswerViewModel
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int TestQuestionId { get; set; }

        public virtual TestQuestion Question { get; set; }
    }
}