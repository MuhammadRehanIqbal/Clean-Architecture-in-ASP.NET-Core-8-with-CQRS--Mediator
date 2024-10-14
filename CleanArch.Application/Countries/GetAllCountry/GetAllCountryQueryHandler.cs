using CleanArch.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.GetAllCountry
{
    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<CountryResponse>>
    {
        private readonly ICountryRepository _countryrepository;
        public GetAllCountryQueryHandler(ICountryRepository countryrepository)
        {
            _countryrepository = countryrepository;
        }
        public async Task<List<CountryResponse>> Handle(GetAllCountryQuery query, CancellationToken cancellationToken)
        {
            var countryies = await _countryrepository.GetAllCountry();

            return countryies.Select(country => new CountryResponse
            {
                Id = country.Id,
                Iso = country.Iso,
                Name = country.Name,
                PhoneCode = country.PhoneCode
            }).ToList();
        }  

    }
}
