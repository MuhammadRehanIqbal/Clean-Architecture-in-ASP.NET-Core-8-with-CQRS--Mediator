using CleanArch.Application.Authentication.Common;
using CleanArch.Application.Authentication.Queries.Login;
using CleanArch.Application.Common.Interfaces.Authentication;
using CleanArch.Application.Common.Interfaces.Persistence;
using CleanArch.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Queries.Balance
{

    public class BalanceQueryHandler : IRequestHandler<BalanceQuery, BalanceResponse>
    {
        private readonly IUserRepository _userRepository;

        public BalanceQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BalanceResponse> Handle(BalanceQuery query, CancellationToken cancellationToken)
        {
            var balance = await _userRepository.GetBalance(query.Username);

            // Return a response object based on the balance
            return new BalanceResponse
            {
                // Map balance data to response properties
                UserBalance = balance.UserBalance,
                Type = balance.BalanceType 
            };
        }
    }
}
