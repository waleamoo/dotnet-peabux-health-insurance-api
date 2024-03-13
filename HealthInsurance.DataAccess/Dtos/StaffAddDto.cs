using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Dtos
{
    public class StaffAddDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }
        [Required]
        [StringLength(50)]
        public string StaffSurname { get; set; }
        [Required]
        [StringLength(50)]
        public string StaffAddress { get; set; }
        [Required]
        public int StaffRole { get; set; }
    }
}
