using System;
namespace InsuranceCore.Models.DTOs.Ticket
{
	public class AddTicketDto : ADto, ITicketDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Problem { get; set; }
        public string? Comment { get; set; }
        public int Status { get; set; }
        public int? Assign { get; set; }
        public int Product { get; set; }
    }
}

