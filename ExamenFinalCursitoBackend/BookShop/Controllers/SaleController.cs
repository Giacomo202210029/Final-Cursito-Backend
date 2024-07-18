using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinalCursitoBackend.BookShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;
    
    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    
    [HttpGet("{id}")]
    public ActionResult GetSaleById(int id)
    {
        var sale = _saleService.GetSaleById(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }
    
    [HttpPost]
    public ActionResult CreateSale([FromBody] Sale sale)
    {
        _saleService.AddSale(sale);
        return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
    }
}