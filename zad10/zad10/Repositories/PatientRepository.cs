using Microsoft.EntityFrameworkCore;
using zad10.Context;
using zad10.DTOs;
using zad10.Entities;

namespace zad10.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly MsdbContext _msdbContext;

    public  PatientRepository(MsdbContext msdbContext)
    {
        _msdbContext = msdbContext;
    }

    public async Task AddNewPatient(PrescriptionToAdd prescriptionToAdd)
    {
        var result = await _msdbContext.Patients.CountAsync(x =>
            x.IdPatient == prescriptionToAdd.patient.IdPatient && x.FirstName == prescriptionToAdd.patient.FirstName);
        if (result == 0)
        {
            Patient patient = new Patient()
            {
                FirstName = prescriptionToAdd.patient.FirstName
            };
            await _msdbContext.Patients.AddAsync(patient);
            await _msdbContext.SaveChangesAsync();
        }
    }

    public async Task<ResultDTO> GetPatientInfo(int id)
    {


        //TUTAJ NIE DZIALA!!!!!!!!!!!!
        await using (var context = new MsdbContext())
        {
            var patient = await context.Patients
                .Include(p => p.Prescriptions)
                .ThenInclude(p2 => p2.Doctor)
                .Include(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPatient == id);

            // var patient = await _msdbContext.Patients
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p => p.Doctors)
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p => p.PrescriptionMedicaments)
            //     .ThenInclude(pm => pm.Medicament)
            //     .FirstOrDefaultAsync(p => p.IdPatient == id);
            
            // await using var context = new MsdbContext();
            // var patient = await context.Patients
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p2 => p2.Doctor)
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p2 => p2.PrescriptionMedicaments)
            //     .ThenInclude(pm => pm.Medicament)
            //     .FirstOrDefaultAsync(p => p.IdPatient == id);

            
            // var patient1 = await context.Patients
            //     .Include(p => p.Prescriptions)
            //     .FirstOrDefaultAsync(p => p.IdPatient == id);
            //
            // var patientWithDoctors = await context.Patients
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p2 => p2.Doctor)
            //     .FirstOrDefaultAsync(p => p.IdPatient == id);
            //
            // var patientWithMedicaments = await context.Patients
            //     .Include(p => p.Prescriptions)
            //     .ThenInclude(p2 => p2.PrescriptionMedicaments)
            //     .ThenInclude(pm => pm.Medicament)
            //     .FirstOrDefaultAsync(p => p.IdPatient == id);


            if (patient == null)
            {
                return new ResultDTO(404, "Patient not found");
            }

            var patientDto = new PatientDTO
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Prescriptions = patient.Prescriptions.OrderBy(p => p.DueDate).Select(p => new PrescriptionDTO
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentsToAdd()
                    {
                        idMedicament = pm.Medicament.IdMedicament,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description
                    }).ToList(),
                    dOCTOR = new DoctorToAdd()
                    {
                        idDoctor = p.Doctors.IdDoctor,
                        FirstName = p.Doctors.FirstName
                    }
                }).ToList()
            };

            return new ResultDTO(200, "git", patientDto);
        }
    }

}