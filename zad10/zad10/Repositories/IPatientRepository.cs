using zad10.DTOs;

namespace zad10.Repositories;

public interface IPatientRepository
{
    Task<int> AddNewPatient(PrescriptionToAdd prescriptionToAdd);
    Task<ResultDTO> GetPatientInfo(int id);
} 