using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }


        [Required]
        [ForeignKey(nameof(User))]
        public string ClientId { get; set; }

        public virtual User Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
