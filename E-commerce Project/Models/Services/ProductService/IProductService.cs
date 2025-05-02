using E_commerce_Project.Models.ViewModels.ProductViewModel;

namespace E_commerce_Project.Models.Services.ProductService;

public interface IProductService
{
    // Command
    Task CreateProductAsync(ProductCreateViewModel model);
    Task UpdateProductAsync(int id, ProductUpdateViewModel model);
    Task DeleteProductAsync(int id);
    Task ForceDeleteProductAsync(int id);
    // Query
}