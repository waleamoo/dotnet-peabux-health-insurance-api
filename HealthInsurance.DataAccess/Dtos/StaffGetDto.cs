using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Dtos
{
    public class StaffGetDto
    {
        public Guid StaffGuid { get; set; }

        public int? CompanyId { get; set; }

        public string StaffName { get; set; } = string.Empty;

        public string StaffEmail { get; set; } = string.Empty;

        public string StaffSurname { get; set; } = string.Empty;

        public string StaffAddress { get; set; } = string.Empty;

        public Company? Company { get; set; }

    }
}
