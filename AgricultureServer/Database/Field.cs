using System;
using System.Collections.Generic;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class Field
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public double Square { get; set; }

        public virtual Crop Crop { get; set; }
    }
}
