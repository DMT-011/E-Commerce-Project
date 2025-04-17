using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class Role : AuditableEntity
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    
    public ICollection<User> Users { get; set; }
}