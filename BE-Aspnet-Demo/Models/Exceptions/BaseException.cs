using System.Text.Json.Serialization;

namespace be_aspnet_demo.models.exceptions;

public class BaseException: Exception
{
    
    public BaseException(string errorCode, string message, int httpStatusCode) : base(message)
    {
        HTTPStatusCode = httpStatusCode;
        ErrorCode = errorCode;
    }
    
    [JsonIgnore]
    public int HTTPStatusCode { get; set; }
    
    public string ErrorCode { get; set; }
    
}