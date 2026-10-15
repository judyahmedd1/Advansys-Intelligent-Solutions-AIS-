using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("Enrollments")]
    public class Enrollments
    {
        [Key]
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Students Student { get; set; }

        public int CourseSectionID { get; set; }
        [ForeignKey("CourseSectionID")]
        public CourseSections CourseSection { get; set; }

        public DateTime StudentEnrollmentDate { get; set; } = DateTime.Now;

        [MaxLength(2)]
        public string? Grade { get; set; }             // nullable in SQL
    }

    [Table("CourseSections_Enrollments")]
    [PrimaryKey(nameof(EnrollmentID), nameof(CourseSectionID))]
    public class CourseSections_Enrollments
    {
        public int EnrollmentID { get; set; }
        [ForeignKey("EnrollmentID")]
        public Enrollments Enrollment { get; set; }

        public int CourseSectionID { get; set; }
        [ForeignKey("CourseSectionID")]
        public CourseSections CourseSection { get; set; }
    }
}
