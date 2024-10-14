using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {

            var blog = await blogRepository.GetByIdAsync(request.BlogId);
            var results =mapper.Map<BlogVm>(blog) ;

            return results;

        }
    }
}
