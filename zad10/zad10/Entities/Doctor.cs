using System.ComponentModel.DataAnnotations;

namespace zad10.Entities;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Email { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}