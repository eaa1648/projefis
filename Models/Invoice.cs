public class Invoice
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime Date { get; set; }
    public string SerialNumber { get; set; }
    public InvoiceStatus Status { get; set; }

    // Navigation Property
    public Customer Customer { get; set; }

    // InvoiceDetails ile ilişki
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}
