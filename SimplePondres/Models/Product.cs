using System.ComponentModel.DataAnnotations;

namespace SimplePondres.Models
{
    public class Product
    {
        // Properties
        public int ProductId { get; set; }
        [MaxLength(60)]public string Name { get; set; }
        public int Stock { get; set; } 
        [MaxLength(200)]public string Description { get; set; }

        [MaxLength(30)]public string Type { get; set; }
        [MaxLength(200)]public string ExternalReference { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}
