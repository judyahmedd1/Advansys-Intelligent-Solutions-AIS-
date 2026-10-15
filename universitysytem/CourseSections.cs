using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("CourseSections")]
    public class CourseSections
    {
        [Key]
        public int CourseSectionID { get; set; }

        [Required, MaxLength(50)]
        public string CourseSectionSchedule { get; set; }

        public short CourseSectionCapacity { get; set; }

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Courses Course { get; set; }

        public int SemesterID { get; set; }
        [ForeignKey("SemesterID")]
        public Semesters Semester { get; set; }

        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public Instructors Instructor { get; set; }

        public int ClassroomID { get; set; }
        [ForeignKey("ClassroomID")]
        public Classrooms Classroom { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
