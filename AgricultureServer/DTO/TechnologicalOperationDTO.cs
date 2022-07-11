namespace AgricultureServer.DTO
{
    public class TechnologicalOperationDTO
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public string OperationName { get; set; }
        public int? ProcessingOfOneHectareDuration { get; set; }
    }
}