using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.DataAccess.Dtos
{
    public class StaffAddDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string StaffName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string StaffSurname { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string StaffAddress { get; set; } = string.Empty;
        [StringLength(50)]
        [EmailAddress]
        public string StaffEmail { get; set; } = string.Empty;
        [Required]
        public int StaffRole { get; set; }
        [Required]
        [StringLength(50)]
        [Compare("ConfirmPassword", ErrorMessage = "Password and confirm password field must match")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
