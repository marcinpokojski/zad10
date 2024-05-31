namespace zad10.DTOs;

public class ResultDTO
{
    public int Code { get; set; }
    public string Message { get; set; }

    public ResultDTO(int code, string message)
    {
        Code = code;
        Message = message;
    }
}