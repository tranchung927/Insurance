using System;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Ticket;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.TicketService
{
	public interface ITicketService
	{
        Task<IEnumerable<GetTicketDto>> GetAllTickets();

        public Task<IEnumerable<GetTicketDto>> GetTickets(FilterSpecification<Ticket>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Ticket>? sortSpecification = null);

        public Task<int> CountTicketsWhere(FilterSpecification<Ticket>? filterSpecification = null);

        Task<GetTicketDto> GetTicket(int id);

        Task<GetTicketDto> AddTicket(AddTicketDto ticket);

        Task UpdateTicket(UpdateTicketDto ticket);

        Task DeleteTicket(int id);
    }
}

