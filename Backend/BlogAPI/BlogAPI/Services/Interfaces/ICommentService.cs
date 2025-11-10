using BlogAPI.Model.DTO;

namespace BlogAPI.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentDTO> CreateComment(CommentCreateDTO newComment);
    }
}
