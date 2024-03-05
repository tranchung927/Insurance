﻿
using InsuranceCore.Models.Sort;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Models.Builders.Specifications.User
{
    /// <summary>
    /// Class used to generate <see cref="SortSpecification{TEntity}"/> for <see cref="User"/>.
    /// </summary>
    public class UserSortSpecificationBuilder
    {
        private readonly Order _order;
        private readonly UserSort _sort;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSortSpecificationBuilder"/> class.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        public UserSortSpecificationBuilder(Order order, UserSort sort)
        {
            _order = order;
            _sort = sort;
        }

        /// <summary>
        /// Get sort specification of <see cref="User"/> based of internal properties defined.
        /// </summary>
        /// <returns></returns>
        public SortSpecification<Data.User> Build()
        {
            var sort = _sort switch
            {
                UserSort.Username => new SortSpecification<Data.User>(
                    new OrderBySpecification<Data.User>(x => x.UserName),
                    _order == Order.Desc
                        ? SortingDirectionSpecification.Descending
                        : SortingDirectionSpecification.Ascending),
                UserSort.Registration => new SortSpecification<Data.User>(
                    new OrderBySpecification<Data.User>(x => x.RegisteredAt),
                    _order == Order.Desc
                        ? SortingDirectionSpecification.Descending
                        : SortingDirectionSpecification.Ascending),
                UserSort.Email => new SortSpecification<Data.User>(
                    new OrderBySpecification<Data.User>(x => x.Email),
                    _order == Order.Desc
                        ? SortingDirectionSpecification.Descending
                        : SortingDirectionSpecification.Ascending),
                UserSort.LastLogin => new SortSpecification<Data.User>(
                    new OrderBySpecification<Data.User>(x => x.LastLogin),
                    _order == Order.Desc
                        ? SortingDirectionSpecification.Descending
                        : SortingDirectionSpecification.Ascending),
                _ => new SortSpecification<Data.User>(
                    new OrderBySpecification<Data.User>(x => x.RegisteredAt),
                    _order == Order.Desc
                        ? SortingDirectionSpecification.Descending
                        : SortingDirectionSpecification.Ascending)
            };

            return sort;
        }
    }
}
