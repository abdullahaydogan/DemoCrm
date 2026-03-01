using DemoCRM.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCRM.Persistance.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Branch)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.ContactValue)
                   .HasMaxLength(50);

            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(x => x.CreatedDate)
                   .IsRequired();

            builder.Property(x => x.UpdatedDate)
                   .IsRequired(false);

            builder.HasIndex(x => x.Email)
                   .IsUnique();
            builder.HasMany(t => t.Courses).WithMany(c => c.Teachers);
        }
    }
}
