using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace universitysytem
{
    [Table("Departments")]
    public class Departments
    {

        [Key]
        public int DepartmentID { get; set; }
        [Required]
        [Length(2, 50)]
        public string DepartmentName { get; set; }
        [Required]
        [MaxLength(20)]
        public string DepartmentBuilding { get; set; }
        [Required]
        [Precision(12, 2)]
        public decimal DepartmentBudget { get; set; }
    }
}
