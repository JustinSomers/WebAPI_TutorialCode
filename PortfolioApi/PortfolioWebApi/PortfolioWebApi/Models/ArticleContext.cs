using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApi.Models
{
    public class ArticleContext: DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {}

        public DbSet<Article> Articles { get; set; }
    }
}
