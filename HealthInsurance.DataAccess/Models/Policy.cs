using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class Policy
{
    public string PolicyId { get; set; } = null!;

    public Guid PolicyGuid { get; set; }

    public int? CompanyId { get; set; }

    public string PolicyType { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Discount { get; set; }

    public string Benefits { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<PolicyHolder> PolicyHolders { get; set; } = new List<PolicyHolder>();
}
