using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesList;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.DeleteEventCommand;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.UpdateEventCommand;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsList;
using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
        CreateMap<Event, EventDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryEventListVm>();

        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, CategoryEventDto>().ReverseMap();
    }
    
}