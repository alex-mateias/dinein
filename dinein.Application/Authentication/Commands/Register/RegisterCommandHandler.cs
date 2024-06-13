using dinein.Application.Authentication.Common;
using dinein.Application.Common.Interfaces.Authentication;
using dinein.Application.Common.Interfaces.Persistence;
using dinein.Domain.Common.Errors;
using dinein.Domain.Entities;
using ErrorOr;
using MediatR;

namespace dinein.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}