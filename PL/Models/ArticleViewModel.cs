using System;

namespace PL.Models
{
    /// <summary>
    /// Article view model.
    /// </summary>
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}