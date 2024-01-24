using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NYX.Commodities.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string ProductColor { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; } = "";
    }
}
