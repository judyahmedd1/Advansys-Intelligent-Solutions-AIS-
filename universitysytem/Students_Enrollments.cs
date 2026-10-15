using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("Students_Enrollments")]
    [PrimaryKey(nameof(EnrollmentID), nameof(StudentID))]
    public class Students_Enrollments
    {
        public int EnrollmentID { get; set; }
        [ForeignKey("EnrollmentID")]
        public Enrollments Enrollment { get; set; }

        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Students Student { get; set; }
    }
}
