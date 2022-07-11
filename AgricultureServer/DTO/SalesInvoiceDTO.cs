namespace AgricultureServer.DTO
{
    public class SalesInvoiceDTO
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}