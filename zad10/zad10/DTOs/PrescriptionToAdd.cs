namespace zad10.DTOs;

public class PrescriptionToAdd
{
    public PatientToAdd patient { get; set; }
    public DoctorToAdd doctor { get; set; }
    public List<MedicamentsToAdd> Medicaments { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
}