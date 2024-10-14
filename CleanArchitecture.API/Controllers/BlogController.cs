using CleanArchitecture.Application.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Blogs.Queries.GetBlogById;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet("allblogs")]
        public async Task<ActionResult> GetAllBlogs()
        {
            var blogs = await Mediator.Send(new GetBlogsQuery());
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllById(int id)
        {

            var blogs = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blogs == null)
            {
                return NotFound();
            }
            return Ok(blogs);
        }
        [HttpPost]
        [ProducesResponseType(typeof(BlogVm), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
        {

            var blogs = await Mediator.Send(createBlogCommand);

            return CreatedAtAction(nameof(GetAllById), new { id = blogs.Id }, blogs);
        }
        [HttpPatch]

        public async Task<ActionResult> UpdateBlog(int id, UpdateBlogCommand updateBlogCommand)
        {

            if (id != updateBlogCommand.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(updateBlogCommand);
            return NoContent();
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBlog(int id)
        {

            int output = await Mediator.Send(new DeleteBlogCommand { Id = id });
            if(output > 0)
            {
                return Ok($"Requested ID is Deleted Successfully.."+id);
            }
            else if(output < 0) 
            {
                return Ok("No Records Found");
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
