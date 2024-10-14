using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blocgdto = new Blog()
            {
                Author = request.Author,
                Description = request.Description,
                Id = request.Id,
                Name = request.Name
            };
          var response= await blogRepository.UpdateAsync(request.Id, blocgdto);

            return response;

        }
    }
}
