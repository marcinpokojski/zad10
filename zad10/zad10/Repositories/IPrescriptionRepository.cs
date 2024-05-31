using zad10.DTOs;

namespace zad10.Repositories;

public interface IPrescriptionRepository
{
    Task<int> AddNewPrescription(PrescriptionToAdd prescriptionToAdd);
    Task<bool> CheckIfMax10Medicaments(PrescriptionToAdd prescriptionToAdd);
}