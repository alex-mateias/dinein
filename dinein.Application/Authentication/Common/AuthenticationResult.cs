using dinein.Domain.Entities;

namespace dinein.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}