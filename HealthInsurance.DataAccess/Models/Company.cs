using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public Guid CompanyGuid { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<PolicyHolder> PolicyHolders { get; set; } = new List<PolicyHolder>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
