using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad10.Entities;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patients { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctors { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
}