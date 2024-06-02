namespace zad10.DTOs;

public class PrescriptionDTO
{
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<MedicamentsToAdd> Medicaments { get; set; }
        public DoctorToAdd dOCTOR { get; set; }
}