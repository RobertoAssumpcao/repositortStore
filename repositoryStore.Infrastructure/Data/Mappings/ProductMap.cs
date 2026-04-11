using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using repositoryStore.Domain.Entities;

namespace repositoryStore.Infrastructure.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityAlwaysColumn() // Define que o Id será gerado automaticamente pelo PostgreSQL (IDENTITY ALWAYS). O banco SEMPRE gera o valor, e não permite inserção manual de Id.
            .UseSerialColumn(); 

        builder.Property(x => x.Title)
            .HasColumnType("varchar")
            .HasMaxLength(160)
            .IsRequired(true);
            
        builder.Property(x => x.Slug)
            .HasColumnType("varchar")
            .HasMaxLength(160)
            .IsRequired(true);

        builder.Property(x => x.CreatedAtUtc)
            .IsRequired(true);
            
        builder.Property(x => x.UpdatedAtUtc)
            .IsRequired(true);
            
        builder.HasIndex(x => x.Slug)
            .IsUnique()
            .HasDatabaseName("idx_products_slug");
    }
}