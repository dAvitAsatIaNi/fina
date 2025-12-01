using System.Threading.Tasks;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddProductAsync(Product product)
    {
        return await _repository.AddProductAsync(product);
    }
    
    public async Task<int> UpdateProductAsync(Product product)
    {
        return await _repository.UpdateProductAsync(product);
    }
    
    public async Task<int> DeleteProductAsync(int id)
    {
        return await _repository.DeleteProductAsync(id);
    }
    
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _repository.GetProductsAsync();
    }

    public async Task<List<Product>> GetProductByIdAsync(int id)
    {
        return await _repository.GetProductByIdAsync(id);
    }
}