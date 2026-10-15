using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("UniPrograms")]
    public class UniPrograms
    {
        [Key]
        public int ProgramID { get; set; }
        [Required]
        [Length(2, 50)]
        public string ProgramName { get; set; }
        [Required]
        [Length(2, 50)]
        public string DegreeType { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public int FK_Department { get; set; }
        public ICollection<Departments> Departments { get; set; }


    }
}
