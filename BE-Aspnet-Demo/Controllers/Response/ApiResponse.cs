using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace be_aspnet_demo.controllers.response;

public class ApiResponse
{
    public bool Success { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Data { get; set; }
    
    [JsonPropertyName("code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorCode { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorMessage { get; set; }
    
    public ApiResponse(bool isSuccess)
    {
        Success = isSuccess;
    }
    
    public ApiResponse(object data)
    {
        Success = true;
        Data = data;
    }
}   