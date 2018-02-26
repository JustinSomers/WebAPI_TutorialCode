using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApi.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly AWSConnections conn;
        private readonly ArticleContext _context;
        public ArticleController(ArticleContext context, AWSConnections connection)
        {
            conn = connection;
            _context = context;

            conn.GetRDSConnectionString();
            if (_context.Articles.Count() == 0)
            {
                _context.Articles.Add(new Article { Title = "Test Article", Date = new DateTime(), content = "foo foo foo foo foo" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        [HttpGet("{id}", Name = "GetArticle")]
        public IActionResult Get(int id)
        {
            var item = _context.Articles.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Article item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Articles.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArticle", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Article item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var article = _context.Articles.FirstOrDefault(t => t.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            article.Date = item.Date;
            article.Title = item.Title;
            article.content = item.content;

            _context.Articles.Update(article);
            _context.SaveChanges();
            return new ObjectResult(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return new NoContentResult();
        }





    }
}
