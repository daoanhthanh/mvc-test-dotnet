using AutoMapper;
using be_aspnet_demo.models.user;
using be_aspnet_demo.models.user.dto;
using be_aspnet_demo.models.user.form;

namespace be_aspnet_demo.config;

public class AutoMapperConfig: Profile
{
    
    public AutoMapperConfig()
    {
        CreateModelsToViewModels();
        CreateViewModelsToModels();
    }

    private void CreateModelsToViewModels()
    {
        CreateMap<UserQuery, UserQueryForm>();
    }

    private void CreateViewModelsToModels()
    {
        CreateMap<UserQueryForm, UserQuery>();
        CreateMap<UserDTO, User>();
    }
}