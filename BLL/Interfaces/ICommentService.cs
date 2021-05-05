using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Interface for getting methods from comment service.
    /// </summary>
    public interface ICommentService
    {
        void AddComment(CommentDTO orderDto);
        IEnumerable<CommentDTO> GetComments();
        CommentDTO GetComment(int? id);
        void Dispose();
    }
}