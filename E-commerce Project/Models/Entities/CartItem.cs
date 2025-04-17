using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class CartItem : AuditableEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } 
    public decimal TotalPrice { get; set; }
    
    public int CartId { get; set; }
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    public Cart Cart { get; set; }
}