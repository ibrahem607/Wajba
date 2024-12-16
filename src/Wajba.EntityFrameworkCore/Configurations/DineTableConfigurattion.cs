global using Wajba.Models.BranchDomain;

namespace Wajba.Configurations;

public class DineTableConfigurattion : IEntityTypeConfiguration<DineInTable>
{
    public void Configure(EntityTypeBuilder<DineInTable> builder)
    {
        builder.ToTable("DineInTables");

    }
}
