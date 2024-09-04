using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetCompanyById(int id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult> AddCompany([FromBody] Company company)
    {
        await _companyService.AddCompanyAsync(company);
        return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCompany(int id, [FromBody] Company company)
    {
        if (id != company.Id) return BadRequest();
        await _companyService.UpdateCompanyAsync(company);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompany(int id)
    {
        await _companyService.DeleteCompanyAsync(id);
        return NoContent();
    }
}
