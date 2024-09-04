public class CustomerService
{
    private readonly IGenericRepository<Customer> _repository;

    public CustomerService(IGenericRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _repository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
