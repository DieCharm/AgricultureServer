namespace AgricultureServer.DTO
{
    public class WorkOrderDTO
    {
        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string WorkType { get; set; }
        public int? CompletionTime { get; set; }
    }
}