using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public Guid StaffGuid { get; set; }

    public int? CompanyId { get; set; }

    public string StaffName { get; set; } = null!;

    public string StaffSurname { get; set; } = null!;

    public string StaffAddress { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public byte[]? Password { get; set; }

    public byte[]? PasswordKey { get; set; }

    public string? StaffEmail { get; set; }

    public virtual Company? Company { get; set; }
}
