namespace car_management_api.Dtos
{
    public class MonthlyRequestsReportDto
    {
        public int Requests { get; set; }
        public YearMonth YearMonth { get; set; }
    }

    public class YearMonth
    {
        public int Year { get; set; }
        public string Month { get; set; }
        public bool LeapYear { get; set; }
        public int MonthValue { get; set; }
    }

}
