using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using System.Reflection;

namespace POS.Infrastucture.Persistences.Context;

public partial class PosContext : DbContext
{
    public PosContext()
    {
    }

    public PosContext(DbContextOptions<PosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchOffice> BranchOffices { get; set; }
    public virtual DbSet<Business> Businesses { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<MenuRole> MenuRoles { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Provider> Providers { get; set; }
    public virtual DbSet<Province> Provinces { get; set; }
    public virtual DbSet<Purcharse> Purcharses { get; set; }
    public virtual DbSet<PurcharseDetail> PurcharseDetails { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<SaleDetail> SaleDetails { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<UsersBranchOffice> UsersBranchOffices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de las entidades de manera global
        modelBuilder.HasAnnotation("Relational:Collation", "ModernSpanish_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
