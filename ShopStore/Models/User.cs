using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using ShopStore.Constants;

namespace ShopStore.Models;

public class User
{

    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public Role Role { get; set; }

    [JsonIgnore]
    public required string PasswordHash { get; set; }
}

