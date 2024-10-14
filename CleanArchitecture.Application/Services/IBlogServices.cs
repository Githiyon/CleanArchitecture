using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> DeleteAsync(int id, Blog blog);
        Task<int> UpdateAsync(int id, Blog blog);
    }
}
