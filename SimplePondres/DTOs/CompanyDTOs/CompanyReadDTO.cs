using System.ComponentModel.DataAnnotations;

namespace SimplePondres.DTOs.CompanyDTOs
{
    public class CompanyReadDTO
    {
        // Properties
        public int CompanyId { get; set; }
        [MaxLength(60)] public string CompanyName { get; set; }
        public int CompanyPhoneNumber { get; set; }
        [MaxLength(60)] public string Email { get; set; }

    }
}
