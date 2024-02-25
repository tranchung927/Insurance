﻿using System;
using System.Linq.Expressions;
using Server.Data.Contracts;

namespace Server.Specifications.FilterSpecifications.Filters
{
    public class LastLoginAfterDateSpecification<TEntity> : FilterSpecification<TEntity> where TEntity : class, IPoco, IHasLastLogin
    {
        private readonly DateTimeOffset _date;

        public LastLoginAfterDateSpecification(DateTimeOffset date)
        {
            _date = date;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.LastLogin > _date;
    }
}
