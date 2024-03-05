using System;
using AutoMapper;
using InsuranceCore.Repositories.Ticket;

namespace InsuranceCore.Models.DTOs.Ticket.Converters
{
	public class TicketIdConverter : ITypeConverter<int, Data.Ticket>
    {
        private readonly ITicketRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostIdConverter"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public TicketIdConverter(ITicketRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.Ticket Convert(int source, Data.Ticket destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

