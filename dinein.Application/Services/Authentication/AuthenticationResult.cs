using dinein.Domain.Entities;

namespace dinein.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}