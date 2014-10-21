using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shipper2.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [DisplayName("Category")]
        public int ProductCategoryId { get; set; }
        [DisplayName("Retailer")]
        public int RetailerId { get; set; }
        [Required(ErrorMessage = "A Retailer is required")]
        [StringLength(160)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public decimal Price { get; set; }
        [DisplayName("InStock")]
        public Int32 Quantity { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [DisplayName("Product Image")]
        [StringLength(1024)]
        public string ProductImage { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Retailer Retailer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}