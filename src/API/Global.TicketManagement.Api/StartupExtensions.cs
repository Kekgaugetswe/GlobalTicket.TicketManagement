using GlobalTicket.TicketManagement.Application;
using GlobalTicket.TicketManagement.Infastructure;
using GlobalTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Global.TicketManagement.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddCors(options => options.AddPolicy("open", policy => policy.WithOrigins("https://localhost:7020", builder.Configuration["BlazorUrl" ?? "https://localhost:7080"]).AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(pol=> true)));

        builder.Services.AddOpenApi();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();
        app.MapOpenApi();
        app.MapScalarApiReference(opt =>
        {
            opt.WithTitle("Global Ticket Management API").WithTheme(theme: ScalarTheme.BluePlanet);
        });
        
        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<GlobalTicketDbContext>();
            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
            

        }
        catch (Exception e)
        {
            
            //add loggin later on
            
            
        }
    }
}