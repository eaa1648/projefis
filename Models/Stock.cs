public class Stock
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; }

    // InvoiceDetails ile ilişki
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}
