public class InvoiceDetail
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int StockId { get; set; }
    public decimal Quantity { get; set; }

    // Navigation Properties
    public Invoice Invoice { get; set; }
    public Stock Stock { get; set; }
}
