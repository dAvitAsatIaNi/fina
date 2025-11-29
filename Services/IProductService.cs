using System.Threading.Tasks;

public interface IProductService
{
    Task<int> AddProductAsync(Product product);
    Task<int> UpdateProductAsync(Product product);
    Task<int> DeleteProductAsync(int id);
    Task<List<Product>> GetProductsAsync();
}