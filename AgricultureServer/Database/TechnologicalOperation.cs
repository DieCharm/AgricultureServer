using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class TechnologicalOperation
    {
        public TechnologicalOperation()
        {
            PlannedRequirements = new HashSet<PlannedRequirement>();
            PlannedWaybills = new HashSet<PlannedWaybill>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        public int Id { get; set; }
        public int? CropId { get; set; }
        public string OperationName { get; set; }
        public int? ProcessingOfOneHectareDuration { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual ICollection<PlannedRequirement> PlannedRequirements { get; set; }
        public virtual ICollection<PlannedWaybill> PlannedWaybills { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
