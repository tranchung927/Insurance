using Microsoft.AspNetCore.Mvc;
using Server.Models.Queries.Interfaces;
using System.ComponentModel;

namespace Server.Models.Queries
{
    public class GetTagQueryParameters : APaginationQuery, IOrderQuery
    {
        /// <summary>
        /// Order the return tags by Ascending or Descending
        /// </summary>
        [DefaultValue(Order.Asc)]
        [FromQuery(Name = "orderBy")]
        public Order OrderBy { get; set; } = Order.Asc;

        /// <summary>
        /// Returns only tags whose name contains the given parameter
        /// </summary>
        [FromQuery(Name = "inName")]
        public string InName { get; set; } = null;
    }
}
