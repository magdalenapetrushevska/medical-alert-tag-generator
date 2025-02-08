using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Persistence.Configurations
{
    public class MedicalAlertTagConfiguration : IEntityTypeConfiguration<MedicalAlertTag>
    {
        public void Configure(EntityTypeBuilder<MedicalAlertTag> builder)
        {
            // Define table name
            builder.ToTable("MedicalAlertTags");

            // Set primary key
            builder.HasKey(m => m.Id);

            // Configure properties
            builder.Property(m => m.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.DateOfBirth)
                   .IsRequired();

            builder.Property(m => m.MedicalConditions)
                   .IsRequired();

            builder.Property(m => m.EmergencyContactPhone)
                   .IsRequired();

            // Configure Created and LastModified properties to be handled as immutable and modifiable timestamps
            builder.Property(m => m.Created)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(m => m.LastModified)
                   .IsRequired()
                   .ValueGeneratedOnUpdate();

            // Optional: Add indexes for better query performance
            builder.HasIndex(m => m.FullName);
        }
    }
}
