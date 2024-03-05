﻿using Microsoft.AspNetCore.Mvc;
using InsuranceCore.Models.Queries.Interfaces;
using System.ComponentModel;

namespace InsuranceCore.Models.Queries
{
    public class GetRoleQueryParameters : APaginationQuery, IOrderQuery
    {
        /// <summary>
        /// Order the return roles by Ascending or Descending
        /// </summary>
        [DefaultValue(Order.Asc)]
        [FromQuery(Name = "orderBy")]
        public Order OrderBy { get; set; } = Order.Asc;
    }
}
