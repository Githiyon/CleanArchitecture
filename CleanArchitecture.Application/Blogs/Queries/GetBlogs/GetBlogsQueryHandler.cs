using CleanArchitecture.Domain.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogVm>>
    {
        private readonly IBlogRepository blogRepository;

        public GetBlogsQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public async Task<List<BlogVm>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
           var blog=  await blogRepository.GetAllBlockAsync();

            var results= blog.Select(x=> new BlogVm { Author=x.Author,Name=x.Name,Description=x.Description,Id=x.Id}).ToList();
            return results;
     

        }
    }
}
