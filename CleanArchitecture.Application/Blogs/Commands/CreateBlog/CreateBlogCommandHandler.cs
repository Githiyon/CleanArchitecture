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

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {


            var datadto = new Blog()
            {
                Name = request.Name,
                Author = request.Author,
                Description = request.Description,
                //Id = request.Id,

            };

            //var reqmap = mapper.Map<Blog>(request);

            var results = await blogRepository.CreateAsync(datadto);


            //var datafinal = new BlogVm()
            //{
            //    Name = results.Name,
            //    Author = results.Author,
            //    Description = results.Description,
            //    Id = results.Id,

            //};
            return mapper.Map<BlogVm>(results);


        }
    }
}
