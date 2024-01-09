using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public int State { get; set; }

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
}
