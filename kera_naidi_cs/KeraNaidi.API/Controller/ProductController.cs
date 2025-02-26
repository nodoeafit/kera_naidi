using KeraNaidi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [Route("AddProduct")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        var result = await _productService.AddProduct(product);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [Authorize]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }

}