using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using PL.Models;

namespace PL.Controllers
{
    /// <summary>
    /// Controller for guest page.
    /// </summary>
    public class GuestController : Controller
    {
        private readonly ICommentService commentService;
        public GuestController(ICommentService serv)
        {
            commentService = serv;
        }

        public ActionResult Guest()
        {
            IEnumerable<CommentDTO> commentDtos = commentService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);
            return View(comments);
        }

        [HttpPost]
        public ActionResult Guest(string author, string text)
        {
            if (string.IsNullOrEmpty(author))
            {
                ModelState.AddModelError("AuthorName", "No author");
            }
            if (string.IsNullOrEmpty(text))
            {
                ModelState.AddModelError("Text", "No text");
            }

            if (ModelState.IsValid)
            {
                var commentDto = new CommentDTO
                {
                    AuthorName = author,
                    Text = text
                };
                commentService.AddComment(commentDto);
            }

            return Guest();
        }

        protected override void Dispose(bool disposing)
        {
            commentService.Dispose();
            base.Dispose(disposing);
        }
    }
}