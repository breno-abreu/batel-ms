using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BatelMS.Api.Entities;

public partial class BaseTable
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }
}

public class BaseTableConfiguration : IEntityTypeConfiguration<BaseTable>
{
    public void Configure(EntityTypeBuilder<BaseTable> builder)
    {
        builder.ToTable("base_table");

        builder.HasKey(baseTable => baseTable.Id);

        builder.Property(baseTable => baseTable.Id)
            .HasColumnName("id");

        builder.Property(baseTable => baseTable.Name)
            .HasColumnName("name")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(baseTable => baseTable.Description)
            .HasColumnName("description")
            .HasMaxLength(500);
    }
}
