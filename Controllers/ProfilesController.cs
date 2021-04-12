using System.Collections.Generic;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _pservice;
        private readonly BlogsService _blogService;

        public ProfilesController(ProfilesService pservice, BlogsService blogService)
        {
            _pservice = pservice;
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                return Ok(_pservice.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/blogs")]
        public ActionResult<CreatorBlog> GetBlogs(string id)
        {
            try
            {
                return Ok(_blogService.GetByCreatorId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}