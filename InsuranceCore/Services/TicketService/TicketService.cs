using System;
using AutoMapper;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Ticket;
using InsuranceCore.Repositories.Ticket;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.TicketService
{
	public class TicketService: ITicketService
	{
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(ITicketRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetTicketDto>> GetAllTickets()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetTicketDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetTicketDto>> GetTickets(FilterSpecification<Ticket>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Ticket>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetTicketDto>(x));
        }

        public async Task<int> CountTicketsWhere(FilterSpecification<Ticket>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetTicketDto> GetTicket(int id)
        {
            return _mapper.Map<GetTicketDto>(await _repository.GetAsync(id));
        }

        public async Task<GetTicketDto> AddTicket(AddTicketDto ticket)
        {
            var result = await _repository.AddAsync(_mapper.Map<Ticket>(ticket));
            _unitOfWork.Save();
            return _mapper.Map<GetTicketDto>(result);
        }

        public async Task UpdateTicket(UpdateTicketDto ticket)
        {
            var ticketEntity = await _repository.GetAsync(ticket.Id);
            _mapper.Map(ticket, ticketEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteTicket(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

