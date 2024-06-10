using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Doctor
{
    [Key] public int IdDoctor { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] public string LastName { get; set; } = string.Empty;
    [MaxLength(100)] public string Email { get; set; } = string.Empty;

    public ICollection<Prescription> Orders { get; set; } = new HashSet<Prescription>();
}