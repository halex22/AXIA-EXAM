using BlogAPI.Model;
using BlogAPI.Model.DTO;
using BlogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _context;

        public PostService (BlogDbContext context)
        {
            _context = context;
        }

        public async Task<PostDTO> CreatePost(PostCreateDTO newPost)
        {
            var post = new Post
            {
                Body = newPost.Body,
                Title = newPost.Title,

            };
            _context.Posts.Add(post);  
            await _context.SaveChangesAsync();

            return ConvertToDTO(post);
        }

        public async Task DeletePost(int Id)
        {
            var result = await _context.Posts.FindAsync(Id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No Post with id {Id} was found");
            }

            _context.Posts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDTO>> GetAllPost()
        {
            var result = await _context.Posts.ToListAsync();
            return result.Select(p => ConvertToDTO(p));
        }

        public async Task<PostDTO> GetPostById(int Id)
        {
            var result = await _context.Posts.FindAsync(Id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No Post with id {Id} was found");
            }
            return ConvertToDTO(result);
        }

        public PostDTO ConvertToDTO(Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                Body = post.Body,
                CreatedAt = post.CreatedAt,
                Title = post.Title,
            };
        }
        
    }
}
