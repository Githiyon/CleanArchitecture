using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogService _blogService;
        public BlogService(IBlogService blogService)
        {

            _blogService = blogService;

        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            return await _blogService.CreateAsync(blog);
        }

        public  async Task<int> DeleteAsync(int id, Blog blog)
        {
            return await _blogService.DeleteAsync(id, blog);  
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogService.GetAllAsync();
        }

        public async Task<Blog> GetAsync(int id)
        {
           return await _blogService.GetAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {

            return await (_blogService.UpdateAsync(id,blog));
        }
    }
}
