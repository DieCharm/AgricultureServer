using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class Crop
    {
        public Crop()
        {
            CropIncomeAndExpenses = new HashSet<CropIncomeAndExpense>();
            Fields = new HashSet<Field>();
            SalesInvoices = new HashSet<SalesInvoice>();
            TechnologicalOperations = new HashSet<TechnologicalOperation>();
        }

        public int Id { get; set; }
        public string CropName { get; set; }
        public int PlannedWeight { get; set; }

        public virtual ICollection<CropIncomeAndExpense> CropIncomeAndExpenses { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
        public virtual ICollection<SalesInvoice> SalesInvoices { get; set; }
        public virtual ICollection<TechnologicalOperation> TechnologicalOperations { get; set; }
    }
}
