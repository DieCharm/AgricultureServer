using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class CropIncomeAndExpense
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public int? Year { get; set; }
        public decimal? Income { get; set; }
        public decimal? Expenses { get; set; }

        public virtual Crop Crop { get; set; }
    }
}
