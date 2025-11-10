using BlogAPI.Model.DTO;

namespace BlogAPI.Services.Interfaces
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDTO>> GetAllPost();
        public Task<PostDTO> GetPostById(int Id);
        public Task<PostDTO> CreatePost(PostCreateDTO newPost);
        public Task DeletePost(int Id);
    }
}
