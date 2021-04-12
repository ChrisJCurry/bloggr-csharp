using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _blogService;

        public BlogsController(BlogsService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_blogService.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            try
            {
                return Ok(_blogService.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> CreateAsync([FromBody] Blog blog)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                blog.CreatorId = userInfo.Id;
                Blog created = _blogService.Create(blog);
                return Ok(created);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Blog> Edit(int id, [FromBody] Blog blog)
        {
            try
            {
                blog.Id = id;
                return Ok(_blogService.Edit(blog));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Blog> Delete(int id)
        {
            try
            {
                return Ok(_blogService.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}