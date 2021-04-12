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
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentService;

        public CommentsController(CommentsService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            try
            {
                return Ok(_commentService.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            try
            {
                return Ok(_commentService.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("blog/{blogId}")]
        [Authorize]
        public async Task<ActionResult<Comment>> Create(int blogId, [FromBody] Comment comment)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                comment.CreatorId = userInfo.Id;
                comment.BlogId = blogId;
                Comment created = _commentService.Create(comment);
                return Ok(created);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}