using ExampleTest2.Data;
using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    // public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
    // {
    //     return await _context.Orders
    //         .Include(e => e.Client)
    //         .Include(e => e.OrderPastries)
    //         .ThenInclude(e => e.Pastry)
    //         .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
    //         .ToListAsync();
    // }
    public async Task<bool> PatientExists(int patientId)
    {
        return await _context.Patients
            .Where(e => e.IdPatient == patientId)
            .AnyAsync();
    }

    public async Task<bool> DoctorExists(int doctorId)
    {
        return await _context.Doctors
            .Where(e => e.IdDoctor == doctorId)
            .AnyAsync();
    }

    public async Task NewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task NewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task NewPrescriptionMedicaments(List<PrescriptionMedicament> prescriptionMedicaments)
    {
        await _context.AddRangeAsync(prescriptionMedicaments);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Prescription>> GetPrescriptionsForPatient(int idPatient)
    {
        return await _context.Prescriptions
            .Where(e => e.IdPatient == idPatient)
            .Include(e => e.Doctor)
            .Include(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Medicament)
            .ToListAsync();
    }

    public async Task<Patient> GetPatientData(int idPatient)
    {
        return await _context.Patients
            .Where(e => e.IdPatient == idPatient)
            .FirstAsync();
    }
}