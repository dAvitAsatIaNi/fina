using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRepository
{
    Task<int> AddProductAsync(Product product);
    Task<int> UpdateProductAsync(Product product);
    Task<int> DeleteProductAsync(int id);
    Task<List<Product>> GetProductsAsync();

    Task<List<Product>> GetProductByIdAsync(int id);

}