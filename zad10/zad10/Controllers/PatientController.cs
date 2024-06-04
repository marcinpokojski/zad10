using Microsoft.AspNetCore.Mvc;
using zad10.Services;

namespace zad10.Controllers;


[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PatientController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    [HttpGet]
    [Route("api/patient/{id}")]
    public async Task<IActionResult> GetPatientInfo(int id)
    {
        var result = await _prescriptionService.GetPatientInfo(id);

        if (result.Code == 200)
        {
            return Ok(result.PatientDTO);
        }

        return NotFound(result.Code);
    }
    
}