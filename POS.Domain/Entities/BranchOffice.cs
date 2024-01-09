using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class BranchOffice
{
    public int BranchOfficeId { get; set; }

    public string Code { get; set; } = null!;

    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DistrictId { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int State { get; set; }

    public virtual Business Business { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UsersBranchOffice> UsersBranchOffices { get; set; } = new List<UsersBranchOffice>();
}
