using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class StaffRoleType
{
    public int StaffRoleTypeId { get; set; }

    public string StaffRoleTitle { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<StaffRole> StaffRoles { get; set; } = new List<StaffRole>();
}
