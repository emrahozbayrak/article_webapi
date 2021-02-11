using Article.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        // GET: api/<CommentsController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _commentService.Table.Where(p => !p.IsDeleted).ToListAsync();
            if (result == null) return NotFound();

            return Ok(result);
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _commentService.GetById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/<CommentsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Article.Core.Entities.Comment model)
        {
            model.CreatedDate = DateTime.Now;

            await _commentService.InsertAsync(model);

            return CreatedAtAction("Get", model);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Article.Core.Entities.Comment model)
        {
            model.UpdatedDate = DateTime.Now;

            _commentService.Update(model);

            return NoContent();
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = _commentService.GetById(id);
            if (article == null) return NotFound();

            article.IsDeleted = true;
            _commentService.Update(article);

            return NoContent();
        }
    }
}
