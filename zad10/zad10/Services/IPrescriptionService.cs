using zad10.DTOs;

namespace zad10.Services;

public interface IPrescriptionService
{
    Task<ResultDTO> AddPrescription(PrescriptionToAdd prescriptionToAdd);
}