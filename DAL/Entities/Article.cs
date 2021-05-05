using System;

namespace DAL.Entities
{
    /// <summary>
    /// Article entity model.
    /// </summary>
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
