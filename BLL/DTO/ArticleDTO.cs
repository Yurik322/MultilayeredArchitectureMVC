using System;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for article model.
    /// </summary>
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}