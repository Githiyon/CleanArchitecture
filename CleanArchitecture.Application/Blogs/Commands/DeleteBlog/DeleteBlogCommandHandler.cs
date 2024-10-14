using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
           
            return await blogRepository.DeleteAsync(request.Id);
        }
    }
}
