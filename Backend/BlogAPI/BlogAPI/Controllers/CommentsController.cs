using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Model;
using BlogAPI.Services.Interfaces;
using BlogAPI.Model.DTO;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController( ICommentService service)
        {
            _service = service;
        }


        // GET: api/Comments/5
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetComment([FromRoute]int postId)
        {
            var result = await _service.GetPostComments(postId);

            return Ok(result);
        }



        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody]CommentCreateDTO comment)
        {
            var result = await _service.CreateComment(comment);

            return Created(String.Empty, result);

        }

    }
}
