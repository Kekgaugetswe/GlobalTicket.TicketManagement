using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Models.Mail;
using GlobalTicket.TicketManagement.Infastructure.FileExport;
using GlobalTicket.TicketManagement.Infastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagement.Infastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICsvExporter, CsvExporter>();
        return services;

    }
}