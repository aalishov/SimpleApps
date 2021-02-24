using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class Type
    {
        public Type()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
