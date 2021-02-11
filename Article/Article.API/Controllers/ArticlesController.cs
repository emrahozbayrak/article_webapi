﻿using Article.Core.Services;
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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _articleService.Table.Where(p => !p.IsDeleted).ToListAsync();
            if (result == null) return NotFound();

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _articleService.GetById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // Searching with Article Title
        [HttpGet("getbytitle/{keyword}")]
        public async Task<IActionResult> GetByTitleAsync(string keyword)
        {
            var result = await _articleService.GetByTitleAsync(keyword);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // Searching with Author Name
        [HttpGet("getbyauthor/{authorName}")]
        public async Task<IActionResult> GetByAuthorAsync(string authorName)
        {
            var result = await _articleService.GetByTitleAsync(authorName);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Article.Core.Entities.Article model)
        {
            model.CreatedDate = DateTime.Now;

            await _articleService.InsertAsync(model);

            return CreatedAtAction("Get", model);
        }

        [HttpPut]
        public IActionResult Put(Article.Core.Entities.Article model)
        {
            model.UpdatedDate = DateTime.Now;

            _articleService.Update(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var article = _articleService.GetById(id);
            if (article == null) return NotFound();

            article.IsDeleted = true;
            _articleService.Update(article);

            return NoContent();
        }
    }
}
