﻿using E_commerce_Project.Models.Common;

namespace E_commerce_Project.Models.Entities;

public class User : AuditableEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int Gender { get; set; } // 1: male, 2: female, 3: other
    public string? Avatar { get; set; }
    public int AccountStatus { get; set; }
    
    public int RoleId { get; set; }
    public Cart Cart { get; set; }
    public Role Role { get; set; }
    public ICollection<Order> Orders { get; set; }
}