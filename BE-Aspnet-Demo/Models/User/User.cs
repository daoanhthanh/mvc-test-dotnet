using System.Text.Json.Serialization;

namespace be_aspnet_demo.models.user;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateOnly DoB { get; set; }
    
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
};