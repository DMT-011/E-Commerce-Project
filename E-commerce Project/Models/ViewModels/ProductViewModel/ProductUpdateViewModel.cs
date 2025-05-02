namespace E_commerce_Project.Models.ViewModels.ProductViewModel;

public class ProductUpdateViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public string Slug { get; set; }
    public string Price { get; set; }
    public string? PromotionPrice { get; set; }
    public int Quantity { get; set; }
    public bool HasDiscount { get; set; } 
    public bool IsDisplayed { get; set; }
    
    public int CategoryId { get; set; }
}