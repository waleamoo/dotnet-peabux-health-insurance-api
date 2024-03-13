using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class PolicyHolder
{
    public string PolicyHolderId { get; set; } = null!;

    public Guid PolicyHolderGuid { get; set; }

    public int? CompanyId { get; set; }

    public string? PolicyId { get; set; }

    public string PolicyHolderName { get; set; } = null!;

    public string PolicyHolderSurname { get; set; } = null!;

    public DateOnly PolicyHolderDateOfBirth { get; set; }

    public string PolicyHolderAddress { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual Company? Company { get; set; }

    public virtual Policy? Policy { get; set; }
}
