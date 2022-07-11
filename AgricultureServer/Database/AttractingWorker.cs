using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class AttractingWorker
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? QualificationId { get; set; }
        public int Quantity { get; set; }

        public virtual WorkOrder Order { get; set; }
        public virtual WorkerQualification Qualification { get; set; }
    }
}
