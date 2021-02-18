using BlogsApi.Helpers;
using BlogsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var blogs = await blogService.GetAllBlogs();

            var blogModels = BlogHelper.ConvertBlogs(blogs);

            return Ok(blogModels);
        }
    }
}
