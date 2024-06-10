using System.Transactions;
using ExampleTest2.Models;
using ExampleTest2.Models.DTOs;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    [Route("new/")]
    public async Task<IActionResult> NewPrescription(NewPrescriptionDTO request)
    {
        if (request.Medicaments.Count > 10)
            return BadRequest("Prescription cannot have more than 10 medicaments");
        if (request.DueDate < request.Date)
            return BadRequest("DueDate must be >= Date");
        if (!await _dbService.DoctorExists(request.DoctorId))
            return BadRequest("No such doctor");
        Patient patient = new Patient()
        {
            FirstName = request.Patient.FirstName,
            LastName = request.Patient.LastName,
            Birthdate = request.Patient.Birthdate,
        };
        Prescription prescription;

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            if (!await _dbService.PatientExists(request.Patient.IdPatient))
                await _dbService.NewPatient(patient);
            prescription = new Prescription()
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = request.DoctorId
            };
            await _dbService.NewPrescription(prescription);
            List<PrescriptionMedicament> prescriptionMedicaments = [];
            foreach (var medicamentDto in request.Medicaments)
            {
                prescriptionMedicaments.Add(new PrescriptionMedicament()
                {
                    IdMedicament = medicamentDto.IdMedicament,
                    IdPrescription = prescription.IdPrescription,
                    Details = medicamentDto.Details,
                    Dose = medicamentDto.Dose
                });
            }
            
            await _dbService.NewPrescriptionMedicaments(prescriptionMedicaments);

            scope.Complete();
        }

        return Created("api/prescription", new
        {
            Id = prescription.IdPrescription
        });
    }
}