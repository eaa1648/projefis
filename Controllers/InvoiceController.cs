using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly InvoiceService _invoiceService;

    public InvoiceController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null) return NotFound();
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<ActionResult> AddInvoice([FromBody] Invoice invoice)
    {
        await _invoiceService.AddInvoiceAsync(invoice);
        return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
        if (id != invoice.Id) return BadRequest();
        await _invoiceService.UpdateInvoiceAsync(invoice);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInvoice(int id)
    {
        await _invoiceService.DeleteInvoiceAsync(id);
        return NoContent();
    }
}
