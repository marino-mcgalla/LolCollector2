using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinApp.Data;
using Microsoft.EntityFrameworkCore;
using LolApp.Models;
using SkinApp.Services;
using Microsoft.AspNetCore.Identity;
using SkinApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SkinApp.API
{
    [Route("api/[controller]")]
    public class ForumController : Controller
    {
        private IForumService _repo;

        private readonly UserManager<ApplicationUser> _userManager;

        public ForumController(IForumService repo, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _repo.GetPosts();
            return Ok(posts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _repo.GetPost(id);
            return Ok(post);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ForumPost post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userId = _userManager.GetUserId(User);
                _repo.SavePost(userId, post);
                return Ok();
            }
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeletePost(id);
            return Ok();
        }
    }
}
