using System;
using InsuranceCore.Models.Queries.Interfaces;
using InsuranceCore.Models.Sort;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Xml.Linq;

namespace InsuranceCore.Models.Queries
{
	public class GetTicketQueryParameters : APaginationQuery, IOrderQuery
    {
        /// <summary>
        /// Order the return categories by Ascending or Descending
        /// </summary>
        [DefaultValue(Order.Asc)]
        [FromQuery(Name = "orderBy")]
        public Order OrderBy { get; set; } = Order.Asc;
    }
}

