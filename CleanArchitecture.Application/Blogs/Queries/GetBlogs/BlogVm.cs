using CleanArchitecture.Application.Comman.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm:IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        //public string Imageurl { get; set; }
    }
}
