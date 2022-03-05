namespace TaxCalculation.Models
{
    public class ResultBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string Error { get; set; }
    }
}
