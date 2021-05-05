using System;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    /// <summary>
    /// Comment view model.
    /// </summary>
    public class CommentViewModel
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