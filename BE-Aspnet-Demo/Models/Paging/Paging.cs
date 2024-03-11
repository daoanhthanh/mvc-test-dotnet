namespace be_aspnet_demo.models.paging;

public class Paging<T>
{
    public required int Total { get; init; } = 0;
    public int CurrentPage { get; set; } = 1;
    public int CurrentPageSize { get; set; } = 10;
    public required List<T> Items { get; init; } = [];
}
