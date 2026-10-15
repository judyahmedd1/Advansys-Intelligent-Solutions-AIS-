using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("Students")]
    [Index(nameof(StudentEmail), IsUnique = true)]
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        [Required, MaxLength(50)]
        public string StudentFirstName { get; set; }

        [Required, MaxLength(50)]
        public string StudentLastName { get; set; }

        [Required, MaxLength(50)]
        public string StudentEmail { get; set; }

        [MaxLength(20)]
        public string? StudentPhone { get; set; }      // nullable in SQL

        [Required, MaxLength(200)]
        public string StudentAddress { get; set; }

        public DateTime StudentEnrollmentDate { get; set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime StudentDOB { get; set; }

        public int ProgramID { get; set; }
        [ForeignKey("ProgramID")]
        public UniPrograms Program { get; set; }

        public int AdvisorID { get; set; }
        [ForeignKey("AdvisorID")]
        public Instructors Advisor { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
