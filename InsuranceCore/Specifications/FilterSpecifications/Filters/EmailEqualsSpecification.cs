using System;
using System.Linq.Expressions;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Specifications.FilterSpecifications.Filters
{
    public class EmailEqualsSpecification<TEntity> : FilterSpecification<TEntity>
        where TEntity : class, IPoco, IHasEmail
    {
        private readonly string _emailAddress;

        public EmailEqualsSpecification(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.Email == _emailAddress;
    }
}