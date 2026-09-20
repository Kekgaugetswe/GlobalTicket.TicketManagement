using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GlobalTicket.TicketManagement.Infastructure.Mail;

public class EmailService(IOptions<EmailSettings> emailSettings) : IEmailService
{
    public EmailSettings _emailSettings { get; } = emailSettings.Value;

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient (_emailSettings.ApiKey);

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody =  email.Body;

        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };
        
        var sendGridMessage =  MailHelper.CreateSingleEmail(from, to,subject,emailBody,emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);
        return response.StatusCode is System.Net.HttpStatusCode.Accepted or System.Net.HttpStatusCode.OK;
    }
}