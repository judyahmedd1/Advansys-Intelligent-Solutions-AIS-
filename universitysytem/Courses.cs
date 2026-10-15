using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("Courses")]
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        [Length(2, 50)]
        public string CourseName { get; set; }
        [Required]
        [Range(1, 10)]
        public int CourseCredits { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public int FK_Department { get; set; }

        public ICollection <Departments> Departments { get; set; }
        [InverseProperty("Course")]
        public ICollection<CoursesPrerequisite> Prerequisites { get; set; }

        [InverseProperty("PrerequisiteCourse")]
        public ICollection<CoursesPrerequisite> IsPrerequisiteFor { get; set; }
    }
}
