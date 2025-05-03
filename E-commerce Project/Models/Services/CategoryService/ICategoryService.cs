using E_commerce_Project.Models.ViewModels.CategoryViewModel;

namespace E_commerce_Project.Models.Services.CategoryService;

public interface ICategoryService
{
    // Command
    Task CreateCategoryAsync(CategoryCreateViewModel model);
    Task UpdateCategoryAsync(int id, CategoryUpdateViewModel model);
    Task DeleteCategoryAsync(int id);
    Task ForceDeleteCategoryAsync(int id);
}