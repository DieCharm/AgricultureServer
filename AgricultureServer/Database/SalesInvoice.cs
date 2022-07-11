using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class SalesInvoice
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Crop Crop { get; set; }
    }
}
