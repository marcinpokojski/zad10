using zad10.Context;
using zad10.DTOs;
using zad10.Entities;

namespace zad10.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly MsdbContext _msdbContext;

    public PrescriptionRepository(MsdbContext msdbContext)
    {
        _msdbContext = msdbContext;
    }
    public async  Task<int> AddNewPrescription(PrescriptionToAdd prescriptionToAdd)
    {
        if (prescriptionToAdd.DueDate >= prescriptionToAdd.Date)
        {
            Prescription prescription = new Prescription()
            {
                Date = prescriptionToAdd.Date,
                DueDate = prescriptionToAdd.DueDate,
                IdPatient = prescriptionToAdd.patient.IdPatient,
                IdDoctor = prescriptionToAdd.doctor.idDoctor

            };
             _msdbContext.Prescriptions.Add(prescription);
             await _msdbContext.SaveChangesAsync();

             

            foreach (var medicament in prescriptionToAdd.Medicaments)
            {
                PrescriptionMedicament prescriptionMedicament = new PrescriptionMedicament()
                {
                    IdMedicament = medicament.idMedicament,
                    IdPrescription = prescription.IdPrescription,
                    Dose = medicament.Dose,
                    Details = medicament.Description
                };
                _msdbContext.PrescriptionMedicaments.Add(prescriptionMedicament);
                await _msdbContext.SaveChangesAsync();
            }
        }

        return 1;
    }

    public async  Task<bool> CheckIfMax10Medicaments(PrescriptionToAdd prescriptionToAdd)
    {
        var length = prescriptionToAdd.Medicaments.Count();
        if (length > 10)
        {
            return false;
        }

        return true;

    }
}