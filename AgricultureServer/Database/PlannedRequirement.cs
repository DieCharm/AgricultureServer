using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class PlannedRequirement
    {
        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string MaterialName { get; set; }
        public decimal MaterialPricePerUnit { get; set; }
        public double Quantity { get; set; }

        public virtual TechnologicalOperation Operation { get; set; }
    }
}
