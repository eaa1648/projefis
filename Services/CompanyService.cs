using System.Collections.Generic;
using System.Threading.Tasks;

public class CompanyService
{
    private readonly IGenericRepository<Company> _repository;

    public CompanyService(IGenericRepository<Company> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Company> GetCompanyByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddCompanyAsync(Company company)
    {
        await _repository.AddAsync(company);
    }

    public async Task UpdateCompanyAsync(Company company)
    {
        await _repository.UpdateAsync(company);
    }

    public async Task DeleteCompanyAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}