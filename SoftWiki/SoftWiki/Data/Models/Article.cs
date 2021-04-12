using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftWiki.Data.Models
{
    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserId = "12345";
            this.CreatedOn = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public DateTime  CreatedOn { get; set; }
    }
}
