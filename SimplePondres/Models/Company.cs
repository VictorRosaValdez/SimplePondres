using System.ComponentModel.DataAnnotations;

namespace SimplePondres.Models
{
    public class Company
    {
        // Properties
        public int CompanyId { get; set; }
        [MaxLength(60)]public string CompanyName { get; set; }
        public int CompanyPhoneNumber { get; set; }
        [MaxLength(60)] public string Email { get; set; }

        // Navigation Property
        public ICollection<Order> Order { get; set; }
    }
}
