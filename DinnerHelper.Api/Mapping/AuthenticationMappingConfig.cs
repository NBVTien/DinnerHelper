using DinnerHelper.Application.Authentication.Commands.Register;
using DinnerHelper.Application.Authentication.Common;
using DinnerHelper.Application.Authentication.Queries.Login;
using DinnerHelper.Contracts.Authentication;
using Mapster;

namespace DinnerHelper.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<AuthenticationResult, AuthenticateResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}