﻿using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Medicament
{
    [Key] public int IdMedicament { get; set; }
    [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [MaxLength(100)] public string Description { get; set; } = string.Empty;

    [MaxLength(100)] public string Type { get; set; } = string.Empty;

    public ICollection<PrescriptionMedicament> Orders { get; set; } = new HashSet<PrescriptionMedicament>();
}