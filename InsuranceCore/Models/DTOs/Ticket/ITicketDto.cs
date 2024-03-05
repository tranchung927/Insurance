using InsuranceCore.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Models.DTOs.Ticket
{
    /// <summary>
    /// Interface of <see cref="Ticket"/> Dto containing all the common properties of Post Dto Type (GET, ADD, UPDATE).
    /// </summary>
    public interface ITicketDto
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
