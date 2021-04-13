using Microsoft.AspNetCore.Mvc;
using SoftWiki.Data;
using SoftWiki.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftWiki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ArticlesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Article> GetArticlesByCategories()
        {
            List<Article> articles = new List<Article>();

            articles.Add( GetArticleByCategory("JavaScript"));
            articles.Add(GetArticleByCategory("Java"));
            articles.Add(GetArticleByCategory("C#"));
            articles.Add(GetArticleByCategory("Python"));
            articles.RemoveAll(x => x == null);

            return articles;
        }

        [HttpGet("all")]
        public IEnumerable<Article> GetAll()
        {
            return this.context.Articles.ToList();
        }

        private Article GetArticleByCategory(string category)
        {
          return  this.context.Articles
                .Where(x => x.Category == category)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault();
        }
    }
}
