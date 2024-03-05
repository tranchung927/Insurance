using InsuranceCore.Authorization.Attributes;
using InsuranceCore.Data.Permission;
using InsuranceCore.Models.Builders.Specifications;
using InsuranceCore.Models.Builders.Specifications.Ticket;
using InsuranceCore.Models.DTOs.Ticket;
using InsuranceCore.Models.Queries;
using InsuranceCore.Responses;
using InsuranceCore.Services.TicketService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose Category resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        /// <summary>
        /// Initializes a new instance of the <see cref="TicketController"/> class.
        /// </summary>
        /// <param name="ticketService"></param>

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Get list of tickets.
        /// </summary>
        /// <remarks>
        /// Get list of tickets. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetTicketDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTickets([FromQuery] GetTicketQueryParameters parameters)
        {
            parameters ??= new GetTicketQueryParameters();

            var pagingSpecificationBuilder = new PagingSpecificationBuilder(parameters.Page, parameters.PageSize);

            var data = await _ticketService.GetTickets(null,
                pagingSpecificationBuilder.Build(), new TicketSortSpecificationBuilder(parameters.OrderBy).Build());

            return Ok(new PageInsuranceResponse<GetTicketDto>(data, pagingSpecificationBuilder.Page, pagingSpecificationBuilder.Limit,
                await _ticketService.CountTicketsWhere()));
        }

        /// <summary>
        /// Get a ticket by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a ticket by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetTicketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ticketService.GetTicket(id));
        }

        /// <summary>
        /// Add a ticket.
        /// </summary>
        /// <remarks>
        /// Add a ticket.
        /// </remarks>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetTicketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddCategory(AddTicketDto ticket)
        {
            return Ok(await _ticketService.AddTicket(ticket));
        }

        /// <summary>
        /// Update a ticket.
        /// </summary>
        /// <remarks>
        /// Update a ticket.
        /// </remarks>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanUpdate, PermissionTarget.Ticket)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateCategory(UpdateTicketDto ticket)
        {
            if (await _ticketService.GetTicket(ticket.Id) == null)
                return NotFound();
            await _ticketService.UpdateTicket(ticket);
            return Ok();
        }

        /// <summary>
        /// Delete a ticket by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a ticket by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanDelete, PermissionTarget.Ticket)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _ticketService.GetTicket(id) == null)
                return NotFound();
            await _ticketService.DeleteTicket(id);
            return Ok();
        }
    }
}
