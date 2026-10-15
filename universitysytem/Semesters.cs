using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("Semesters")]
    public class Semesters
    {

        [Key]
        public int SemesterID { get; set; }
        [Required]
        [Length(2, 50)]
        public string SemesterName { get; set; }
        [Required]
        public DateTime SemesterStartDate { get; set; }
        [Required]
        public DateTime SemesterEndDate { get; set; }
    }
}
