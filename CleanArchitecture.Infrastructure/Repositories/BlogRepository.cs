using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbContext;
        public BlogRepository(BlogDbContext blogDbContext)
        {
                   _dbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
           await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await _dbContext.Blogs.Where(model=>model.Id==id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlockAsync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(m=>m.Id==id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _dbContext.Blogs
                 .Where(model => model.Id == id)
                 .ExecuteUpdateAsync(setters => setters
                 .SetProperty(m=>m.Description, blog.Description)
                 .SetProperty(m=>m.Name, blog.Name)
                 .SetProperty(m=>m.Author, blog.Author)
                 //.SetProperty(m=>m.Imageurl, blog.Imageurl)
                 );
        }
    }
}
