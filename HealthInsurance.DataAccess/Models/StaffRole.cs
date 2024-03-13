using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class StaffRole
{
    public int StaffRoleId { get; set; }

    public int? StaffRoleTypeId { get; set; }

    public Guid StaffGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual StaffRoleType? StaffRoleType { get; set; }
}
