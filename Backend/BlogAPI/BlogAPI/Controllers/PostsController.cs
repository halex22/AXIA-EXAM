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
    public class PostsController : ControllerBase
    {
        private readonly IPostService _service;

        public PostsController(IPostService service)
        {
            _service = service;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var result = await _service.GetAllPost();
            return Ok(result);

        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute]int id)
        {
            try
            {
                var post = await _service.GetPostById(id);
                return Ok(post);    
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            } 
            catch (Exception ex)
            {
                return BadRequest("Something went wrong please try again");
            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPost(int id, Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(post).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody]PostCreateDTO post)
        {
            try
            {
                var newPost = await _service.CreatePost(post);
                return CreatedAtAction("GetPost", new { id = newPost.Id }, newPost);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute]int id)
        {
            try
            {
                await _service.DeletePost(id);
                return NoContent();
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

    }
}
