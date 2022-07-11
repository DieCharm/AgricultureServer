namespace AgricultureServer.DTO
{
    public class PlannedRequirementDTO
    {
        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string MaterialName { get; set; }
        public decimal MaterialPricePerUnit { get; set; }
        public double Quantity { get; set; }
    }
}