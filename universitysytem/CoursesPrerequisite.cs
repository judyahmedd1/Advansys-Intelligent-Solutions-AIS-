using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("CoursesPrerequisite")]
    [PrimaryKey(nameof(CourseID), nameof(PrerequisiteCourseID))]
    public class CoursesPrerequisite
    {
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Courses Course { get; set; }

        public int PrerequisiteCourseID { get; set; }
        [ForeignKey("PrerequisiteCourseID")]
        public Courses PrerequisiteCourse { get; set; }
    }
}

