using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Dtos
{
    public class StaffLoginDto
    {
        public string StaffEmail { get; set; } = string.Empty;
        public string StaffPassword { get; set; } = string.Empty;
    }
}
