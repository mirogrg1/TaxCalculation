using Newtonsoft.Json;

namespace TaxCalculation.Models
{
    public class Order
    {
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }
        [JsonProperty("from_state")]
        public string FromState { get; set; }
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }
        [JsonProperty("to_state")]
        public string ToState { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("shipping")]
        public decimal Shipping { get; set; }
        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }
    }

    public class LineItem
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("product_tax_code")]
        public string ProductTaxCode { get; set; }
    }
}