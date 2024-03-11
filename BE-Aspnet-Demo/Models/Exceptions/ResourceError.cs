namespace be_aspnet_demo.models.exceptions;

public record ResourceError
{
    public bool Success => false;
    public List<string> Messages { get; private set; }

    public ResourceError(List<string> messages)
    {
        Messages = messages ?? [];
    }

    public ResourceError(string message)
    {
        Messages = [];

        if (!string.IsNullOrWhiteSpace(message))
        {
            this.Messages.Add(message);
        }
    }
}