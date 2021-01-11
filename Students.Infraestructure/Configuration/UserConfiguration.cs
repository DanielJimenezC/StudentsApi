using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.Entity;

namespace Students.Infraestructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(u => u.Username)
                .HasColumnName("username")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(200)
                .HasColumnName("password")
                .IsRequired();


            builder.Property(u => u.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(u => u.CreateAt)
                .HasColumnName("create_at")
                .IsRequired();

            builder.Property(u => u.ModifiedAt)
                .HasColumnName("modified_at")
                .IsRequired();
        }
    }
}
