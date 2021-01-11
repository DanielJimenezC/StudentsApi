using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.Entity;

namespace Students.Infraestructure.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(s => s.Name)
                .HasMaxLength(150)
                .HasColumnName("name")
                .IsRequired();


            builder.Property(s => s.Email)
                .HasMaxLength(150)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(s => s.Phone)
                .HasColumnName("phone")
                .IsRequired();

            builder.Property(s => s.IsActive)
                .HasColumnName("is_active")
                .IsRequired();

            builder.Property(s => s.CreateAt)
                .HasColumnName("create_at")
                .IsRequired();

            builder.Property(s => s.ModifiedAt)
                .HasColumnName("modified_at")
                .IsRequired();
        }
    }
}
