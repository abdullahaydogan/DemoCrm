using DemoCRM.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Persistance.Config
{
    public class CourseConfig : IEntityTypeConfiguration<DemoCRM.Core.Entity.Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DemoCRM.Core.Entity.Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.IsActive).IsRequired();
            // 👇 MANY-TO-MANY CONFIG
            builder .HasMany(c => c.Students).WithMany(s => s.Courses).UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    j => j
                        .HasOne<Student>()
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Course>()
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId");
                        j.ToTable("StudentCourses");
                    });
        }
    }
}
