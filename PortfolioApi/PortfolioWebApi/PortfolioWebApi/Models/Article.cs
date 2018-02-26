using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        // Required]
        public DateTime Date { get; set; }
        // [Required]
        public string content { get; set; }
    }
}
