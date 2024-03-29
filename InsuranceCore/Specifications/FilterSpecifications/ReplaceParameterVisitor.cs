﻿using System.Linq.Expressions;
using System.Collections;

namespace InsuranceCore.Specifications.FilterSpecifications
{
    internal class ReplaceParameterVisitor : ExpressionVisitor, IEnumerable<KeyValuePair<ParameterExpression, ParameterExpression>>
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _parameterMappings = new();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameterMappings.TryGetValue(node, out var newValue) ? newValue : node;
        }

        public void Add(ParameterExpression parameterToReplace, ParameterExpression replaceWith) => _parameterMappings.Add(parameterToReplace, replaceWith);

        public IEnumerator<KeyValuePair<ParameterExpression, ParameterExpression>> GetEnumerator() => _parameterMappings.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
