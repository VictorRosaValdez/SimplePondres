using System.ComponentModel.DataAnnotations;

namespace SimplePondres.DTOs.OrderDTOs
{
    public class OrderReadDTO
    {
        // Properties
        public int OrderId { get; set; }
        [MaxLength(30)] public string State { get; set; }
        public DateTime TimeOfDelivery { get; set; }
        [MaxLength(100)] public string Adress { get; set; }
        [MaxLength(200)] public string ExternalReference { get; set; }
        [MaxLength(500)] public string ExtraRequirements { get; set; }

        // Navigation Property
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
    }
}
