using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class Order : AuditableEntity
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public int OrderStatus { get; set; } // 1: Pending, 2: Processed , 3: Cancelled
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } 
}