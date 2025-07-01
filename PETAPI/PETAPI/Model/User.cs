using System.ComponentModel.DataAnnotations;

namespace PETAPI.Model;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string? Email { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = "User"; 

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}