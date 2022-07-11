namespace AgricultureServer.DTO
{
    public class CropIncomeAndExpensesDTO
    {
        public int Id { get; set; }
        public int? CropId { get; set; }
        public int? Year { get; set; }
        public decimal? Income { get; set; }
        public decimal? Expenses { get; set; }
    }
}