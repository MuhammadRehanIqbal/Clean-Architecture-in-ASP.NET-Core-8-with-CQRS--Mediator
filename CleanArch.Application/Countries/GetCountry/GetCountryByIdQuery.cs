using CleanArch.Application.Authentication.Queries.Balance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.GetCountry
{

    public record GetCountryByIdQuery(int Id) : IRequest<CountryResponse>; 
}
