namespace be_aspnet_demo.models.Form;

public class BaseQuery
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public BaseQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;

        if (Page <= 0)
        {
            Page = 1;
        }

        if (PageSize <= 0)
        {
            PageSize = 10;
        }
    }
}
