namespace GlobalTicket.TicketManagement.Application.Contracts.Responses;

public class BaseResponse
{

    public BaseResponse()
    {
        Success = true;
    }

    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    public BaseResponse(string message)     
    {
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; } =  string.Empty;
    public List<string> ValidationErrors { get; set; }    
}