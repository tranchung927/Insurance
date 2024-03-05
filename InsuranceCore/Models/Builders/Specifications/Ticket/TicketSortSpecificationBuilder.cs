using System;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Models.Builders.Specifications.Ticket
{
    /// <summary>
    /// Class used to generate <see cref="SortSpecification{TEntity}"/> for <see cref="Ticket"/>.
    /// </summary>
    public class TicketSortSpecificationBuilder
    {
        private readonly Order _order;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketSortSpecificationBuilder"/> class.
        /// </summary>
        /// <param name="order"></param>
        public TicketSortSpecificationBuilder(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Get sort specification of <see cref="Ticket"/> based of internal properties defined.
        /// </summary>
        /// <returns></returns>
        public SortSpecification<Data.Ticket> Build()
        {
            var sort = new SortSpecification<Data.Ticket>(
                new OrderBySpecification<Data.Ticket>(x => x.Name),
                _order == Order.Desc
                    ? SortingDirectionSpecification.Descending
                    : SortingDirectionSpecification.Ascending);
            return sort;
        }
    }
}

