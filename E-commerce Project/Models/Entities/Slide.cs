using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class Slide : AuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public int? Priority { get; set; }
    public bool IsDisplayed { get; set; }
}