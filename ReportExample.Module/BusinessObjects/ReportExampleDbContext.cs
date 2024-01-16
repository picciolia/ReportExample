using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace ReportExample.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class ReportExampleContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<ReportExampleEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new ReportExampleEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class ReportExampleDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReportExampleEFCoreDbContext> {
	public ReportExampleEFCoreDbContext CreateDbContext(string[] args) {
		var optionsBuilder = new DbContextOptionsBuilder<ReportExampleEFCoreDbContext>();
		optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ReportExample");
		optionsBuilder.UseChangeTrackingProxies();
		optionsBuilder.UseObjectSpaceLinkProxies();
		return new ReportExampleEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(ReportExampleContextInitializer))]
public class ReportExampleEFCoreDbContext : DbContext {
	public ReportExampleEFCoreDbContext(DbContextOptions<ReportExampleEFCoreDbContext> options) : base(options) {
	}
	//public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<ReportDataV2> ReportDataV2 { get; set; }
	public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
