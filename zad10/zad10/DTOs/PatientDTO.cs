namespace zad10.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PrescriptionToAdd> Prescriptions { get; set; }
    public DoctorToAdd Doctor { get; set; }
    
}