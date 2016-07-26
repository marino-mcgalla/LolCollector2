using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinApp.Data;
using LolApp.Models;
using Microsoft.EntityFrameworkCore;
using SkinApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SkinApp.API
{
    [Route("api/[controller]")]
    public class ReplyController : Controller
    {
        private IReplyService _service;

        public ReplyController(IReplyService service)
        {
            this._service = service;
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Reply reply)
        {
            _service.SaveReply(id, reply);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
