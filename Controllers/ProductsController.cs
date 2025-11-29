using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _productService.AddProductAsync(product);
        
        return Ok(new { Message = "Product created successfully" });
    }
    
    [HttpPut("edit-product")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _productService.UpdateProductAsync(product);
        
        return Ok(new { Message = "Product updated successfully" });
    }
    
    [HttpDelete("delete-product/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _productService.DeleteProductAsync(id);
        
        return Ok(new { Message = "Product deleted successfully" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }
}