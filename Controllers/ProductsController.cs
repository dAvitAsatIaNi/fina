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

    [HttpGet("get-product-by-id/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }
    
    [HttpGet("/Products/Diagram")]
    public async Task<IActionResult> Diagram()
    {
        var products = await _productService.GetProductsAsync();
        var startDate = products.Min(p => p.StartDate);
        var endDate = products.Max(p => p.EndDate);

        var model = new ProductDiagramViewModel
        {
            Products = products,
            StartDate = startDate,
            EndDate = endDate
        };

        return View(model);
    }

}