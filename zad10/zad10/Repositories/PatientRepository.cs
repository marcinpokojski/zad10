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
                IdPatient = prescriptionToAdd.patient.IdPatient,
                FirstName = prescriptionToAdd.patient.FirstName
            };
            await _msdbContext.Patients.AddAsync(patient);
        }
    }

}