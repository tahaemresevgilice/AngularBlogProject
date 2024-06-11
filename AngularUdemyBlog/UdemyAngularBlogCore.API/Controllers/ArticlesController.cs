using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyAngularBlogCore.API.Models;
using UdemyAngularBlogCore.API.Response;

namespace UdemyAngularBlogCore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly UdemyAngularBlogDbContext _context;

        public ArticlesController(UdemyAngularBlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetArticle(int page=1,int pageSize=5)
        {
            try
            {
            IQueryable<Article> query;

            query=_context.Article.Include(x=>x.Category).Include(y=>y.Comment).OrderByDescending(z=>z.PublishDate);

            int totalCount=query.Count();

            var articleRespose=query.Skip((pageSize*(page-1))).Take(5).ToList().Select(x=>new ArticleRespose() {
                Id=x.Id,
                Title=x.Title,
                ContentMain=x.ContentMain,
                ContentSummary=x.ContentSummary,
                Picture=x.Picture,
                ViewCount=x.ViewCount,
                CommentCount=x.Comment.Count,
                Category = new CategoryRespose() {Id=x.Category.Id,Name=x.Category.Name}
            });

            var result = new {
                TotalCount=totalCount,
                Articles =articleRespose
            }
            return Ok(result);
            }
            catch (System.Exception ex)
            {
                return.BadRequset(ex.Message);
            }
           
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articles
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
