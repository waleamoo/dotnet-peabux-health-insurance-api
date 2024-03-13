using System;
using System.Collections.Generic;

namespace HealthInsurance.DataAccess.Models;

public partial class Claim
{
    public int ClaimId { get; set; }

    public Guid ClaimGuid { get; set; }

    public int? CompanyId { get; set; }

    public string? PolicyHolderId { get; set; }

    public string Expense { get; set; } = null!;

    public decimal AmountOfExpenseToBeClaimed { get; set; }

    public decimal TotalAmountOfExpense { get; set; }

    public int? ClaimStatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ClaimStatus? ClaimStatus { get; set; }

    public virtual Company? Company { get; set; }

    public virtual PolicyHolder? PolicyHolder { get; set; }
}
