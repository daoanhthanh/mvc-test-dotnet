using be_aspnet_demo.models.Form;

namespace be_aspnet_demo.models.user.form;

public class UserQuery: BaseQuery
{
    public string? Name { get; set; }
    // những cái khác tương tự
    
    public UserQuery(string? name, int page, int pageSize) : base(page, pageSize)
    {
        Name = name;
    }
    
}


