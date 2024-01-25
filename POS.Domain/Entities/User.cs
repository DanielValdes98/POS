namespace POS.Domain.Entities;

public partial class User : BaseEntity
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Image { get; set; }
    public virtual ICollection<Purcharse> Purcharses { get; set; } = new List<Purcharse>();
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<UsersBranchOffice> UsersBranchOffices { get; set; } = new List<UsersBranchOffice>();
}
