using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class WorkerQualification
    {
        public WorkerQualification()
        {
            AttractingWorkers = new HashSet<AttractingWorker>();
        }

        public int Id { get; set; }
        public string QualificationName { get; set; }
        public decimal? HourlyPayment { get; set; }

        public virtual ICollection<AttractingWorker> AttractingWorkers { get; set; }
    }
}
