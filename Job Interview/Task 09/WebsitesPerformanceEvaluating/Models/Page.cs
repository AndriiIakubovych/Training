namespace WebsitesPerformanceEvaluating.Models
{
    public class Page
    {
        public int PageId { get; set; }
        public string PageAddress { get; set; }
        public int AverageTime { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public string Color { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}