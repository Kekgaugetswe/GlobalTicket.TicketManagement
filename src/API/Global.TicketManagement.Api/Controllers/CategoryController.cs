using GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Commands;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesList;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Global.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategoriesAsync()
        {
            var dtos = await mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos); 
        }

        [HttpGet("allwithevents", Name = "GetAllCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetAllCategoriesWithEventsAsync(bool includeHistory)
        {
            GetCategoriesListwithEventsQuery getCategoriesListwithEventsQuery = new GetCategoriesListwithEventsQuery()
            {
                IncludeHistory = includeHistory
            };
            var dtos  = await mediator.Send(getCategoriesListwithEventsQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory(
            [FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await mediator.Send(createCategoryCommand);
            return Ok(response);
        }
        

    }
}
