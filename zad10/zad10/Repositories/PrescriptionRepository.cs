using System.Runtime.InteropServices.JavaScript;
using zad10.Context;
using zad10.DTOs;
using zad10.Entities;

namespace zad10.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly MsdbContext _msdbContext;
    private IPrescriptionRepository _prescriptionRepositoryImplementation;

    public PrescriptionRepository(MsdbContext msdbContext)
    {
        _msdbContext = msdbContext;
    }
    public async  Task<int> AddNewPrescription(PrescriptionToAdd prescriptionToAdd)
    {
        // if (prescriptionToAdd.DueDate < prescriptionToAdd.Date)
        // {
        //     return -1;
        // }

        Prescription prescription = new Prescription()
            {
                //Date = "2022-12-32"
                //DueDate = prescriptionToAdd.DueDate,
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
                
            }
            await _msdbContext.SaveChangesAsync();
            return 1;
        }
       
    

    public async  Task<bool> CheckIfMax10Medicaments(PrescriptionToAdd prescriptionToAdd)
    {
        var length = prescriptionToAdd.Medicaments.Count;
        if (length > 10)
        {
            return false;
        }

        return true;

    }
}