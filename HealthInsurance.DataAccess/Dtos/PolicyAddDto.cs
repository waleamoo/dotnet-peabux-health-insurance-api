using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.DataAccess.Dtos
{
    public class PolicyAddDto
    {
        [Required]
        public int? CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicyType { get; set; } = string.Empty; // Bronze, Gold, Silver 

        [Required]
        public decimal Price { get; set; }

        public int? Discount { get; set; }
        [Required]
        public string Benefits { get; set; } = null!;
    }
}
