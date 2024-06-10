using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Patient
{
    [Key] public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] public string LastName { get; set; } = string.Empty;
    [DataType(DataType.Date)] public DateTime Birthdate { get; set; }

    public ICollection<Prescription> Orders { get; set; } = new HashSet<Prescription>();
}