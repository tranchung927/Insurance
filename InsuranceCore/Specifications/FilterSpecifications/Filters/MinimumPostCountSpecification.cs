﻿using System;
using System.Linq.Expressions;
using InsuranceCore.Data.Contracts;

namespace InsuranceCore.Specifications.FilterSpecifications.Filters
{
    public class MinimumPostCountSpecification<TEntity> : FilterSpecification<TEntity> where TEntity : class, IPoco, IHasPosts
    {
        private readonly int _number;

        public MinimumPostCountSpecification(int number)
        {
            _number = number;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.Posts.Count >= _number;
    }
}
