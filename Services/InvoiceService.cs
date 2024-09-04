public class InvoiceService
{
    private readonly IGenericRepository<Invoice> _repository;

    public InvoiceService(IGenericRepository<Invoice> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddInvoiceAsync(Invoice invoice)
    {
        await _repository.AddAsync(invoice);
    }

    public async Task UpdateInvoiceAsync(Invoice invoice)
    {
        await _repository.UpdateAsync(invoice);
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
