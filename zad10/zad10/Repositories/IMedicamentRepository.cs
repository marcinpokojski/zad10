using zad10.DTOs;

namespace zad10.Repositories;

public interface IMedicamentRepository
{
    Task<bool> IfMedicamentExist(PrescriptionToAdd prescriptionToAdd);
}