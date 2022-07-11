using System;

namespace AgricultureServer.DTO
{
    public class PlannedWaybillDTO
    {
        public int Id { get; set; }
        public int? OperationId { get; set; }
        public string CarName { get; set; }
        public DateTime WorkTime { get; set; }
        public double FuelConsumptionPerAreaUnit { get; set; }
    }
}