using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace universitysytem;
[Table("Users")]
public class Users
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Length(2, 20)]
    public string Name { get; set; }
    [Required] [MaxLength(50)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
}
