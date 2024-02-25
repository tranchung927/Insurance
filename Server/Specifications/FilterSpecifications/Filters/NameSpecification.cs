﻿using System;
using System.Linq.Expressions;
using Server.Data.Contracts;

namespace Server.Specifications.FilterSpecifications.Filters
{
    public class NameSpecification<TEntity> : FilterSpecification<TEntity> where TEntity : class, IPoco, IHasName
    {
        private readonly string _name;

        public NameSpecification(string name)
        {
            _name = name;
        }

        protected override Expression<Func<TEntity, bool>> SpecificationExpression => p => p.Name == _name;
    }
}