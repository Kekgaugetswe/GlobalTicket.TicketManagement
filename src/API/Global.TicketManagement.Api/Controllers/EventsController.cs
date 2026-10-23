using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.DeleteEventCommand;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.UpdateEventCommand;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController( IMediator mediator) : ControllerBase
    {
        [HttpGet("all", Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEventsAsync()
        {
            var result = mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventByIdAsync(Guid id)
        {
            var getEvenDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await mediator.Send(getEvenDetailQuery));
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEventAsync(Guid id)
        {
            var deleteEventCommand =  new DeleteEventCommand()
            {
                EventId = id
            };
            await mediator.Send(deleteEventCommand);
            return NoContent();
        }
        
        [HttpGet("export", Name = "ExportEvents")]
        public async Task<FileResult> ExportEventsAsync( )
        {
            var fileDto = await mediator.Send(new GetEventsExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);

        }
    }
}
