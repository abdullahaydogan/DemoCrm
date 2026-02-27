using DemoCRM.Core.Entity;
using DemoCRM.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Persistance.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(CrmContext context)
        {
            // DB hazır mı?
            await context.Database.MigrateAsync();

            // ======================
            // COURSE SEED
            // ======================
            if (!await context.Courses.AnyAsync())
            {
                var courses = new List<Course>
                {
                    new Course
                    {
                        Name = "C# Backend",
                        Description = ".NET Core & EF Core",
                        Price = 1500,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "React Frontend",
                        Description = "React + TypeScript",
                        Price = 1200,
                        IsActive = true
                    }
                };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }

            // ======================
            // STUDENT SEED
            // ======================
            if (!await context.Students.AnyAsync())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        Name = "Ali",
                        Surname = "Yılmaz",
                        Email = "ali@test.com",
                        PhoneNumber = "5551112233"
                    },
                    new Student
                    {
                        Name = "Ayşe",
                        Surname = "Demir",
                        Email = "ayse@test.com",
                        PhoneNumber = "5554445566"
                    }
                };

                context.Students.AddRange(students);
                await context.SaveChangesAsync();
            }

            // ======================
            // COURSE ↔ STUDENT RELATION
            // ======================
            var firstCourse = await context.Courses
                .Include(c => c.Students)
                .FirstOrDefaultAsync();

            var firstStudent = await context.Students.FirstOrDefaultAsync();

            if (firstCourse != null && firstStudent != null &&
                !firstCourse.Students.Any(s => s.Id == firstStudent.Id))
            {
                firstCourse.Students.Add(firstStudent);
                await context.SaveChangesAsync();
            }
        }
    }
}
