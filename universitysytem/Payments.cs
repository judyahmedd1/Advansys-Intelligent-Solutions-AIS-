using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem
{
    [Table("Payments")]
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required, MaxLength(20)]
        public string PaymentStatus { get; set; }

        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Students Student { get; set; }
    }
}
