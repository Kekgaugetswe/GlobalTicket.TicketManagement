namespace GlobalTicket.TicketManagement.Application.Contracts.Exceptions;

public class NotfoundException : Exception
{
    public NotfoundException(string name, object key): base($"{name} ({key} is not found")
    {
        
    }
    
}