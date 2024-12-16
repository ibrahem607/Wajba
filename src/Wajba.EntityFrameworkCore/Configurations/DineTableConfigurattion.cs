global using Wajba.Models.DinieTable;

namespace Wajba.Configurations;

public class DineTableConfigurattion : IEntityTypeConfiguration<DineInTable>
{
    public void Configure(EntityTypeBuilder<DineInTable> builder)
    {
        builder.ToTable("DineInTables");
    }
}
