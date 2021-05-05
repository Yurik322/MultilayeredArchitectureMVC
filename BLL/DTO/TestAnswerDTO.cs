using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for answer model.
    /// </summary>
    public class TestAnswerDTO
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int TestQuestionId { get; set; }

        public virtual TestQuestion Question { get; set; }
    }
}