namespace E_commerce_Project.Models.ViewModels.CategoryViewModel;

public class CategoryUpdateViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int? Order { get; set; }
    public bool IsDisplayed { get; set; }
}