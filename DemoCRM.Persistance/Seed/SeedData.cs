using DemoCRM.Core.Entity;
using DemoCRM.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Persistance.Seed
{
    public static class SeedData
    {
        public static async Task SeedAsync(CrmContext context)
        {
            await context.Database.MigrateAsync();

            var now = DateTime.UtcNow;

            // COURSE SEED
            if (!await context.Courses.AnyAsync())
            {
                var courses = new List<Course>
                {
                    new Course
                    {
                        Name = "C# Backend",
                        Description = ".NET Core & EF Core",
                        Price = 1500,
                        IsActive = true,
                        CreatedDate = now
                    },
                    new Course
                    {
                        Name = "React Frontend",
                        Description = "React + TypeScript",
                        Price = 1200,
                        IsActive = true,
                        CreatedDate = now
                    }
                };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }

            // STUDENT SEED
            if (!await context.Students.AnyAsync())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        Name = "Ali",
                        Surname = "Yılmaz",
                        Email = "ali@test.com",
                        PhoneNumber = "5551112233",
                        CreatedDate = now,
                        IsActive = true
                    },
                    new Student
                    {
                        Name = "Ayşe",
                        Surname = "Demir",
                        Email = "ayse@test.com",
                        PhoneNumber = "5554445566",
                        CreatedDate = now,
                        IsActive = true
                    }
                };

                context.Students.AddRange(students);
                await context.SaveChangesAsync();
            }

            // TEACHER SEED
            if (!await context.Teachers.AnyAsync())
            {
                var teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Mehmet",
                        Surname = "Kaya",
                        Email = "mehmet.kaya@test.com",
                        Branch = "Backend",
                        ContactValue = "5559991122",
                        IsActive = true,
                        CreatedDate = now
                    },
                    new Teacher
                    {
                        Name = "Zeynep",
                        Surname = "Arslan",
                        Email = "zeynep.arslan@test.com",
                        Branch = "Frontend",
                        ContactValue = "5558883344",
                        IsActive = true,
                        CreatedDate = now
                    }
                };

                context.Teachers.AddRange(teachers);
                await context.SaveChangesAsync();
            }

            // COURSE - STUDENT RELATION
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

            // COURSE - TEACHER RELATION
            var backendCourse = await context.Courses
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(c => c.Name == "C# Backend");

            var backendTeacher = await context.Teachers
                .FirstOrDefaultAsync(t => t.Branch == "Backend");

            if (backendCourse != null && backendTeacher != null &&
                !backendCourse.Teachers.Any(t => t.Id == backendTeacher.Id))
            {
                backendCourse.Teachers.Add(backendTeacher);
                await context.SaveChangesAsync();
            }
        }
    }
}