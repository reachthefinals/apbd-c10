using ExampleTest2.Models;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    [Route("{idPatient:int}")]
    public async Task<IActionResult> GetPatient(int idPatient)
    {
        if (!await _dbService.PatientExists(idPatient))
            return NotFound();
        Patient patient = await _dbService.GetPatientData(idPatient);
        List<Prescription> prescriptions = await _dbService.GetPrescriptionsForPatient(idPatient);
        return Ok(new
        {
            idPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = prescriptions.Select(p =>
                new
                {
                    p.IdPrescription,
                    p.Date,
                    p.DueDate,
                    Doctor = new
                    {
                        p.Doctor.IdDoctor,
                        p.Doctor.FirstName
                    },
                    Medicaments = p.PrescriptionMedicaments.Select(pm =>
                            new
                            {
                                IdMedicament = pm.Medicament.IdMedicament,
                                Name = pm.Medicament.Name,
                                Dose = pm.Dose,
                                Description = pm.Medicament.Description
                            })
                })
        });
    }
}