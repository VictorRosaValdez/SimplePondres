using System.ComponentModel.DataAnnotations;

namespace SimplePondres.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        // Properties
        [MaxLength(60)] public string Name { get; set; }
        public int Stock { get; set; }
        [MaxLength(200)] public string Description { get; set; }
        [MaxLength(30)] public string Type { get; set; }
        [MaxLength(200)] public string ExternalReference { get; set; }
    }
}
