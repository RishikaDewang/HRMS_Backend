using System;
using System.Collections.Generic;

namespace hrms_backend.Models;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public int EmployeeId { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public decimal GrossSalary { get; set; }

    public int? TotalLeaves { get; set; }

    public int? HalfDayLeaves { get; set; }

    public int? PaidLeaves { get; set; }

    public decimal? ProfessionalTax { get; set; }

    public decimal? IncomeTax { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? Adjustments { get; set; }

    public decimal NetSalary { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
