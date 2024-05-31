using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace zad10.DTOs;

public class PatientToAdd
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
}