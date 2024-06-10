using ExampleTest2.Models;

namespace ExampleTest2.Services;

public interface IDbService
{
    // Task<ICollection<Order>> GetOrdersData(string? clientLastName);
    Task<bool> PatientExists(int patientId);
    Task<bool> DoctorExists(int doctorId);

    Task NewPatient(Patient patient);
    Task NewPrescription(Prescription patient);
    Task NewPrescriptionMedicaments(List<PrescriptionMedicament> prescriptionMedicaments);

    Task<List<Prescription>> GetPrescriptionsForPatient(int idPatient);

    Task<Patient> GetPatientData(int idPatient);
    // Task AddNewOrder(Order order);
    // Task<Pastry?> GetPastryByName(string name);
    // Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries);
}