﻿
using Server.Specifications.SortSpecification;

namespace Server.Models.Builders.Specifications.Role
{
    /// <summary>
    /// Class used to generate <see cref="SortSpecification{TEntity}"/> for <see cref="Role"/>.
    /// </summary>
    public class RoleSortSpecificationBuilder
    {
        private readonly Order _order;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleSortSpecificationBuilder"/> class.
        /// </summary>
        /// <param name="order"></param>
        public RoleSortSpecificationBuilder(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Get sort specification of <see cref="Role"/> based of internal properties defined.
        /// </summary>
        /// <returns></returns>
        public SortSpecification<Data.Role> Build()
        {
            var sort = new SortSpecification<Data.Role>(
                new OrderBySpecification<Data.Role>(x => x.Name),
                _order == Order.Desc
                    ? SortingDirectionSpecification.Descending
                    : SortingDirectionSpecification.Ascending);
            return sort;
        }
    }
}
