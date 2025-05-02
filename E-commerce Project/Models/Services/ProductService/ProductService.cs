using E_commerce_Project.Helpers;
using E_commerce_Project.Models.Context;
using E_commerce_Project.Models.Entities;
using E_commerce_Project.Models.ViewModels.ProductViewModel;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_Project.Models.Services.ProductService;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProductService> _logger;

    public ProductService(ApplicationDbContext context, ILogger<ProductService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task CreateProductAsync(ProductCreateViewModel model)
    {
        var productName = model.Name.Trim();
        var product = await _context.Products
            .Where(item => item.Name == productName)
            .FirstOrDefaultAsync();

        if (product != null)
        {
            throw new Exception("Product name already exists");
        }

        product = new Product
        {
            Name = productName,
            Description = model.Description,
            Detail = model.Detail,
            Slug = SlugHelper.GenerateSlug(productName),
            Price = decimal.Parse(model.Price),
            PromotionPrice = decimal.Parse(model.PromotionPrice),
            Quantity = model.Quantity,
            CategoryId = model.CategoryId,
            IsDisplayed = model.IsDisplayed,
            HasDiscount = model.HasDiscount,
        };
        
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Product: {productName} has created successfully");
    }

    public async Task UpdateProductAsync(int id, ProductUpdateViewModel model)
    {
        var productName = model.Name.Trim();
        var productExistName = await _context.Products
            .Where(item => item.Id != id && item.Name == productName && item.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (productExistName != null)
        {
            throw new Exception("Product name exists");
        }
                
        var product = await _context.Products
            .Where(item => item.Id == id && item.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (product == null)
        {
            throw new Exception("Product not found");
        }
        
        product.Name = productName;
        product.Description = model.Description;
        product.Detail = model.Detail;
        product.Slug = SlugHelper.GenerateSlug(productName);
        product.Price = decimal.Parse(model.Price);
        product.PromotionPrice = decimal.Parse(model.PromotionPrice);
        product.Quantity = model.Quantity;
        product.IsDisplayed = model.IsDisplayed;
        product.HasDiscount = model.HasDiscount;
        
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Product: {productName} has update successfully");
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products
            .Where(item => item.Id == id && item.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (product == null)
        {
            throw new Exception("Product not found"); 
        }
        
        product.IsDeleted = true;
        
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Product: {product} has deleted successfully");
    }

    public async Task ForceDeleteProductAsync(int id)
    {
        var product = await _context.Products
            .Where(item => item.Id == id && item.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (product == null)
        {
            throw new Exception("Product not found"); 
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Product: {product} has deleted from database");
    }
}