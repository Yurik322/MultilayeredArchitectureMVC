using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// Comment entity model.
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(30, MinimumLength = 3)]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please enter your comment text")]
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
