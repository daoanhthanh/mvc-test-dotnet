using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using be_aspnet_demo.utils.formatters;

namespace be_aspnet_demo.models.user.dto;

public record UserDTO
{ 
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    [EmailAddressAttribute]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(11)]
    public string Phone { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }
    
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly DoB { get; set; }
}