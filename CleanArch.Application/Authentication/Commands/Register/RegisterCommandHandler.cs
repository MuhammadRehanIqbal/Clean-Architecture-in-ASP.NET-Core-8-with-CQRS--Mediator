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

namespace CleanArch.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password, 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Device = request.Device,
                IpAddress = request.IpAddress
            };

            return await _userRepository.AddUser(user) != null;
        }
    }
}