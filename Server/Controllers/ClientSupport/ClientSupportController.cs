using Server.Models.ClientSupport;
using Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Server.Helpers;

namespace Server.Controllers.ClientSupport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSupportController : ControllerBase
    {
        // đối tượng _context đại diện cho bảng Information
        private readonly IRepository<TicketModel> _context_Ticket;
        private readonly IRepository<InsuranceTypeModel> _context_InsuranceType;
        


        public ClientSupportController(
              IRepository<TicketModel> contextTicket,
              IRepository<InsuranceTypeModel> contextInsuranceType
        )
        {
            _context_Ticket = contextTicket;
            _context_InsuranceType = contextInsuranceType;
        }

        [HttpPost("AddNewTicket")]
        public async Task<ActionResult<TicketModel>> AddNewTicket(TicketModel entityModel)
        {
            await _context_Ticket.AddNew(entityModel);
            return Ok();
        }

        [HttpGet("GetAllTicket")]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetAllTicket()
        {
            var entityModelList = await _context_Ticket.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("GetAllInsuranceType")]
        public async Task<ActionResult<IEnumerable<InsuranceTypeModel>>> GetAllInsuranceType()
        {
            var entityModelList = await _context_InsuranceType.GetAll();
            return Ok(entityModelList);
        }

        [Authorize(Roles = AppRole.Customer)]
        [HttpPost("UpdateTicket")]
        public async Task<ActionResult<TicketModel>> UpdateTicket(TicketModel entityModel)
        {
            await _context_Ticket.Update(entityModel);
            return Ok();
        }
    }
}
