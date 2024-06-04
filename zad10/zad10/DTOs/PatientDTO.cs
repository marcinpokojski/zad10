namespace zad10.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PrescriptionDTO> Prescriptions { get; set; }
    
    
}