using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class ClaimStatus
{
    public int ClaimStatusId { get; set; }

    public string ClaimStatus1 { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
}
