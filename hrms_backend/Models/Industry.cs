﻿using System;
using System.Collections.Generic;

namespace hrms_backend.Models;

public partial class Industry
{
    public int IndustryId { get; set; }

    public string? IndustryName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
