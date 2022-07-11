using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class PlannedWaybill
    {
        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string CarName { get; set; }
        public DateTime WorkTime { get; set; }
        public double FuelConsumptionPerAreaUnit { get; set; }

        public virtual TechnologicalOperation Operation { get; set; }
    }
}
