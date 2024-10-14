using CleanArch.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.GetCountry
{
public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryResponse>
{
    private readonly ICountryRepository _countryrepository;

    public GetCountryByIdQueryHandler(ICountryRepository countryrepository)
    {
            _countryrepository = countryrepository;
    }

    public async Task<CountryResponse> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
    {
        var country = await _countryrepository.GetCountryById(query.Id);
        if (country == null) return null;

        return new CountryResponse()
        {
            Id = country.Id,
            Iso = country.Iso,
            Name = country.Name,
            PhoneCode = country.PhoneCode
        };
    }
}
}
