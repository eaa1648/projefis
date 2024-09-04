public class StockService
{
    private readonly IGenericRepository<Stock> _repository;

    public StockService(IGenericRepository<Stock> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Stock>> GetAllStocksAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Stock> GetStockByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddStockAsync(Stock stock)
    {
        await _repository.AddAsync(stock);
    }

    public async Task UpdateStockAsync(Stock stock)
    {
        await _repository.UpdateAsync(stock);
    }

    public async Task DeleteStockAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
