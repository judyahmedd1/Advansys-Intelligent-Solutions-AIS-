using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("Classrooms")]
    public class Classrooms
    {

        [Key]
        public int ClassroomID { get; set; }
        [Required]
        [Length(2, 50)]
        public string ClassroomBuilding { get; set; }
        [Required]
        [Length(2, 10)]
        public string RoomNumber { get; set; }
        [Required]
        public int ClassroomCapacity { get; set; }
    }
}
