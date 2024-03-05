using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.Ticket
{
    public class TicketRepository : Repository<Data.Ticket>, ITicketRepository
    {
        public TicketRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

