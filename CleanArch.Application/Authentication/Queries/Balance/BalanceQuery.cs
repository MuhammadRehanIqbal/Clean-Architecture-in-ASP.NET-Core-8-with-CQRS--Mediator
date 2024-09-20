using CleanArch.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Queries.Balance
{

    public record BalanceQuery(string Username) : IRequest<BalanceResponse>;
}
