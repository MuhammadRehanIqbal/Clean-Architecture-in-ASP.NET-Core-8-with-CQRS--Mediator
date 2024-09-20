using CleanArch.Application.Authentication.Common;
using CleanArch.Application.Common.Interfaces.Authentication;
using CleanArch.Application.Common.Interfaces.Persistence;
using CleanArch.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Queries.Login
{

    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new Exception("User does not exist");
                //throw new InvalidUser();
            }


            if (user.Password != query.Password)
            {
                throw new Exception("invalid password");
                //throw new InvalidPassword();
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResponse(
                user.FirstName,
                user.LastName,
                token);
        }
    }
}
