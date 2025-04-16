using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int? Order { get; set; }
    public bool IsDisplayed { get; set; }
    
    public ICollection<Product> Products { get; set; }
}