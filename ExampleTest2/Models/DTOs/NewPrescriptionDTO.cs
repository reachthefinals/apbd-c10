using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models.DTOs;

public class NewPrescriptionDTO
{

    public NewPatientDTO Patient { get; set; }
    public int DoctorId { get; set; }
    public List<PrescriptionMedicamentDTO> Medicaments { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class PrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)] public string Details { get; set; } = string.Empty;
}