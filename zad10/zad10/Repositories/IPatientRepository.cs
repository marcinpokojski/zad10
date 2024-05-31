using zad10.DTOs;

namespace zad10.Repositories;

public interface IPatientRepository
{
    Task AddNewPatient(PrescriptionToAdd prescriptionToAdd);
}