using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly StockService _stockService;

    public StockController(StockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Stock>>> GetAllStocks()
    {
        var stocks = await _stockService.GetAllStocksAsync();
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Stock>> GetStockById(int id)
    {
        var stock = await _stockService.GetStockByIdAsync(id);
        if (stock == null) return NotFound();
        return Ok(stock);
    }

    [HttpPost]
    public async Task<ActionResult> AddStock([FromBody] Stock stock)
    {
        await _stockService.AddStockAsync(stock);
        return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStock(int id, [FromBody] Stock stock)
    {
        if (id != stock.Id) return BadRequest();
        await _stockService.UpdateStockAsync(stock);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStock(int id)
    {
        await _stockService.DeleteStockAsync(id);
        return NoContent();
    }
}
