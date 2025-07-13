using HealthCareSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareSystem.Infrastructure.Configurations
{
    public class DoctorGoogleTokenConfiguration : IEntityTypeConfiguration<DoctorGoogleToken>
    {
        public void Configure(EntityTypeBuilder<DoctorGoogleToken> builder)
        {
            builder.ToTable("DoctorGoogleTokens");

            builder.HasKey(t => t.DoctorId);

            builder.Property(t => t.Email).IsRequired().HasMaxLength(150);

            builder.Property(t => t.AccessToken).IsRequired().HasMaxLength(2000);

            builder.Property(t => t.RefreshToken).IsRequired().HasMaxLength(2000);

            builder.Property(t => t.ExpiresIn).IsRequired();

            builder.HasOne(t => t.Doctor).WithOne()
                .HasForeignKey<DoctorGoogleToken>(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
