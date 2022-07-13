using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual Category Category { get; set; }
    }
}
