using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Dtos
{
    public class CompanyAddDto
    {
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyAddress { get; set; }
    }
}
