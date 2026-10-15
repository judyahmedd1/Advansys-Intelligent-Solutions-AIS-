using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace universitysytem;

public class ApplicationDbContext : DbContext
{
    public DbSet<Users> Users { set; get; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<Instructors> Instructors { get; set; }
    public DbSet<Semesters> Semesters { get; set; }

    public DbSet<Classrooms> Classrooms { get; set; }
    public DbSet<UniPrograms> Programs { get; set; }
    public DbSet<Students> Students { get; set; }
    public DbSet<CourseSections> CourseSections { get; set; }
    public DbSet<Enrollments> Enrollments { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Prerequisite> Prerequisites { get; set; }
    public DbSet<CoursesPrerequisite> Courses_Prerequisite { get; set; }
    public DbSet<CourseSections_Enrollments> CourseSections_Enrollments { get; set; }
    public DbSet<Students_Enrollments> Students_Enrollments { get; set; }
    public object CoursePrerequisite { get; internal set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CoursesPrerequisite>()
            .HasOne(p => p.PrerequisiteCourse)
            .WithMany(c => c.IsPrerequisiteFor)
            .HasForeignKey(p => p.PrerequisiteCourseID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Enrollments>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Enrollments>()
            .HasOne(e => e.CourseSection)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseSectionID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
