using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddProductAsync(Product product)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.AddProduct {product.GroupId}, {product.Code}, {product.Name}, {product.Price}, {product.Country}, {product.StartDate}, {product.EndDate}");
    }
    
    public async Task<int> UpdateProductAsync(Product product)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.UpdateProduct {product.Id}, {product.GroupId}, {product.Code}, {product.Name}, {product.Price}, {product.Country}, {product.StartDate}, {product.EndDate}");
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.DeleteProduct {id}");
    }
    
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products
            .FromSqlInterpolated($"EXEC fina.GetProducts")
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .FromSqlInterpolated($"EXEC fina.GetProductById {id}")
            .ToListAsync();
    }

}