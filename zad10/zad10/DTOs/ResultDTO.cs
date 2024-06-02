namespace zad10.DTOs;

public class ResultDTO
{
    public int Code { get; set; }
    public string Message { get; set; }
    public PatientDTO PatientDTO { get; set; }

    public ResultDTO(int code, string message)
    {
        Code = code;
        Message = message;
    }
    public ResultDTO(int code, string message, PatientDTO patientDto)
    {
        Code = code;
        Message = message;
        PatientDTO = patientDto;
    }
}