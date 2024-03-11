namespace be_aspnet_demo.models.Form;

public record BaseQueryForm
{
    public required int Page { get; init; }
    public required int PageSize { get; init; }
}