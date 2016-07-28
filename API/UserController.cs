using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinApp.Services;
using SkinApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SkinApp.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(IUserService repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet("getallusers")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAllUsers()
        {
            var users = _repo.GetAllUsers();
            return Ok(users);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("admindeletepost/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDeletePost(int id)
        {
            _repo.AdminDeletePost(id);
            return Ok();
        }

        // GET api/values/5
        [HttpGet("getcurrentuser")]
        public IActionResult GetCurrentUser()
        {
            var userId = _userManager.GetUserId(User);
            var user = _repo.GetUser(userId);

            return Ok(user);
        }

        //POST api/values
        [HttpPost("{id}")]
        [Route("saveskins")]
        public IActionResult SaveSkins(string id, [FromBody]string[] skins)
        {
            _repo.SaveSkin(id, skins);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _repo.DeleteUser(id);
            return Ok();
        }

        //DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("removeskin")]
        public IActionResult RemoveSkin(int skinId)
        {
            _repo.RemoveSkin(skinId);
            return Ok();
        }

    }
}
