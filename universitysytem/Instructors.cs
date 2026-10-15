using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("Instructors")]
    [Index(nameof(InstructorFirstName), IsUnique = true)]
    public class Instructors
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        [Length(2, 50)]
        public string InstructorFirstName { get; set; }
        [Required]
        [Length(2, 50)]
        public string InstructorLastName { get; set; }
        [Required]
        [EmailAddress]
        public string InstructorEmail { get; set; }
        
    }
}
