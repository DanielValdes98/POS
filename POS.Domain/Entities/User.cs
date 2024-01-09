using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public int? State { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int? AuditDeleteUser { get; set; }

    public DateTime AuditDeleteDate { get; set; }

    public virtual ICollection<Purcharse> Purcharses { get; set; } = new List<Purcharse>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UsersBranchOffice> UsersBranchOffices { get; set; } = new List<UsersBranchOffice>();
}
