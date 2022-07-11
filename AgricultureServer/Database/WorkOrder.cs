using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            AttractingWorkers = new HashSet<AttractingWorker>();
        }

        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string WorkType { get; set; }
        public int? CompletionTime { get; set; }

        public virtual TechnologicalOperation Operation { get; set; }
        public virtual ICollection<AttractingWorker> AttractingWorkers { get; set; }
    }
}
