﻿using System;
using System.Linq.Expressions;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Specifications.FilterSpecifications.Filters
{
    public class PublishedBeforeDateSpecification<TEntity> : FilterSpecification<TEntity>
        where TEntity : class, IPoco, IHasCreationDate
    {
        private readonly DateTimeOffset _date;

        public PublishedBeforeDateSpecification(DateTimeOffset date)
        {
            _date = date;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.PublishedAt < _date;
    }
}
