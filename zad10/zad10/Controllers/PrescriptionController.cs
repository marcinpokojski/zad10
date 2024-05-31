using Microsoft.AspNetCore.Mvc;
using zad10.DTOs;
using zad10.Services;

namespace zad10.Controllers;
[Route("api/prescriptions")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionToAdd prescriptionToAdd)
    {
        var result = await _prescriptionService.AddPrescription(prescriptionToAdd);
        if (result.Code == 200)
        {
            return Ok();
        }

        return NotFound();
    }
    
}