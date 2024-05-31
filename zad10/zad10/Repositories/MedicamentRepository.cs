using Microsoft.EntityFrameworkCore;
using zad10.Context;
using zad10.DTOs;

namespace zad10.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly MsdbContext _msdbContext;

    public MedicamentRepository(MsdbContext msdbContext)
    {
        _msdbContext = msdbContext;
    }

    public async Task<bool> IfMedicamentExist(PrescriptionToAdd prescriptionToAdd)
    {

        foreach (var med in prescriptionToAdd.Medicaments)
        {
            var result = await _msdbContext.Medicaments.CountAsync(x => x.IdMedicament == med.idMedicament);
            if (result == 0)
            {
                return false;
            }

            
        }
        return true;
    }
}