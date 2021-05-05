namespace DAL.Entities
{
    /// <summary>
    /// TestAnswer entity model.
    /// </summary>
    public class TestAnswer
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int TestQuestionId { get; set; }
        public virtual TestQuestion Question { get; set; }
    }
}
