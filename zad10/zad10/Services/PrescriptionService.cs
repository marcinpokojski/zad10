using zad10.DTOs;
using zad10.Repositories;

namespace zad10.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPatientRepository _patientRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMedicamentRepository medicamentRepository, IPatientRepository patientRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _medicamentRepository = medicamentRepository;
    }
    public async  Task<ResultDTO> AddPrescription(PrescriptionToAdd prescriptionToAdd)
    {
         await _patientRepository.AddNewPatient(prescriptionToAdd);
        //true to git
        var ifMedicamentExist = await _medicamentRepository.IfMedicamentExist(prescriptionToAdd);

        var ifLessThan10 = await _prescriptionRepository.CheckIfMax10Medicaments(prescriptionToAdd);

        if (!ifMedicamentExist)
        {
            return new ResultDTO(404, "medicament nie istnieje");
        }

        if (!ifLessThan10)
        {
            return new ResultDTO(404, "wiecej niz 10 lekow w recepcie");
        }

        var result = await _prescriptionRepository.AddNewPrescription(prescriptionToAdd);

        if (result == 1)
        {
            return new ResultDTO(200, "git");
        }

        return new ResultDTO(404, "blad przy dodawaniu");



    }

    public Task<ResultDTO> GetPatientInfo(int id)
    {
        return _patientRepository.GetPatientInfo(id);
    }
}