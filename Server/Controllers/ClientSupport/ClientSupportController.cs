﻿using Server.Models.ClientSupport;
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
        public async Task<ActionResult<TicketModel>> AddNewTicket(TicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về một phản hồi Bad Request với các thông tin lỗi từ ModelState
            }

            // Xử lý logic khi dữ liệu hợp lệ
            await _context_Ticket.AddNew(model);

            return Ok(); // Trả về một phản hồi thành công
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

        //z[Authorize(Roles = "AppRole.Customer, AppRole.Admin")]
        [HttpPost("UpdateTicket")]
        public async Task<ActionResult<TicketModel>> UpdateTicket(TicketModel entityModel)
        {
            await _context_Ticket.Update(entityModel);
            return Ok();
        }

        [Authorize(Roles = "AppRole.Customer, AppRole.Admin")]
        [HttpPost("DeleteTicket")]
        public async Task<ActionResult<TicketModel>> DeleteTicket(int id)
        {
            await _context_Ticket.Delete(id);
            return Ok();
        }
    }
}