namespace GlobalTicket.TicketManagement.Application.Contracts.Exceptions;

public class BadRequestExceptions : Exception
{
    public BadRequestExceptions(string message) : base(message)
    {
        
    }
}