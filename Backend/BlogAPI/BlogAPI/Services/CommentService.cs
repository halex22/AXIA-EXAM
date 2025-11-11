using BlogAPI.Model;
using BlogAPI.Model.DTO;
using BlogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogDbContext _context;

        public CommentService (BlogDbContext context)
        {
            _context = context;
        }

        public async Task<CommentDTO> CreateComment(CommentCreateDTO newComment)
        {
            var comment = new Comment
            {
                PostId = newComment.PostId,
                Content = newComment.Content,
                Author = newComment.Author,
                
            };

            _context.Add(comment);
            await _context.SaveChangesAsync();

            return ConvertToDTO(comment);

        }

        public async Task<IEnumerable<CommentDTO>> GetPostComments(int postId)
        {
            IQueryable<Comment> query = _context.Comments.AsQueryable();
            query = query.Where(c => c.PostId == postId);
            var result = await query.ToListAsync();
            return result.Select(c => ConvertToDTO(c));
        }

        public CommentDTO ConvertToDTO(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Author = comment.Author,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,    
            };
        }
    }
}
