using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("Prerequisite")]
    public class Prerequisite
    {
        [Key]
        public int PrerequisiteCourseID { get; set; }
    }
}
