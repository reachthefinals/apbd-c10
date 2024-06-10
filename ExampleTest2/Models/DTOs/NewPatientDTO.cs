using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models.DTOs;

public class NewPatientDTO
{
    public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] public string LastName { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
}