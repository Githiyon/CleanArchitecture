using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogsQuery:IRequest<List<BlogVm>>
    {
    }
}
