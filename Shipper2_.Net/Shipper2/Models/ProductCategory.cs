using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipper2.Models
{
    public class ProductCategory
    {
        public Int32 ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
