using System;
using System.Linq.Expressions;
using Server.Data.Contracts;

namespace Server.Specifications.FilterSpecifications.Filters
{
    public class EmailContainsSpecification<TEntity> : FilterSpecification<TEntity> where TEntity : class, IPoco, IHasEmail
    { 
        private readonly string _emailAddress;
            
        public EmailContainsSpecification(string emailAddress) 
        { 
            _emailAddress = emailAddress;
        }
    
        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.Email.Contains(_emailAddress);
    }
}
