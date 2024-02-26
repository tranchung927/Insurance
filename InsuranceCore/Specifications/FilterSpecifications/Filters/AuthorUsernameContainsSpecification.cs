using InsuranceCore.Specifications.FilterSpecifications;
using System;
using System.Linq.Expressions;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Specifications.FilterSpecifications.Filters
{
    public class AuthorUsernameContainsSpecification<TEntity> : FilterSpecification<TEntity> where TEntity : class, IPoco, IHasAuthor
    {
        private readonly string _username;

        public AuthorUsernameContainsSpecification(string username)
        {
            _username = username;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.Author.UserName.Contains(_username);
    }
}
