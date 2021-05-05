using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Class with comment services.
    /// </summary>
    public class CommentService : ICommentService
    {
        private IUnitOfWork Database { get; set; }

        public CommentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// Method for create new CommentDTO object.
        /// </summary>
        /// <param name="commentDto">CommentDTO object.</param>
        /// <returns>new CommentDTO object.</returns>
        public void AddComment(CommentDTO commentDto)
        {
            Comment comment = new Comment
            {
                AuthorName = commentDto.AuthorName,
                Text = commentDto.Text,
                Date = DateTime.Now
            };
            Database.Comments.Create(comment);
            Database.Save();
        }

        /// <summary>
        /// Method for get all CommentDTO objects.
        /// </summary>
        /// <returns>collection of CommentDTO.</returns>
        public IEnumerable<CommentDTO> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetAll());
        }

        /// <summary>
        /// Method for get CommentDTO object by id.
        /// </summary>
        /// <param name="id">id of CommentDTO.</param>
        /// <returns>CommentDTO object.</returns>
        public CommentDTO GetComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Has not id in Comment", "");
            var comment = Database.Comments.Get(id.Value);
            if (comment == null)
                throw new ValidationException("Comment not found", "");

            return new CommentDTO
            {
                Id = comment.Id,
                AuthorName = comment.AuthorName,
                Text = comment.Text,
                Date = comment.Date
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
