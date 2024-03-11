using be_aspnet_demo.models.Form;

namespace be_aspnet_demo.models.user.form;

public record UserQueryForm: BaseQueryForm
{
    public string? Name { get; init; }
}