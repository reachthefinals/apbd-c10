using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Prescription
{
    [Key] public int IdPrescription { get; set; }
    [DataType(DataType.Date)] public DateTime Date { get; set; }
    [DataType(DataType.Date)] public DateTime DueDate { get; set; }

    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

    [ForeignKey(nameof(IdPatient))] public Patient Patient { get; set; } = null!;
    [ForeignKey(nameof(IdDoctor))] public Doctor Doctor { get; set; } = null!;

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } =
        new HashSet<PrescriptionMedicament>();
}