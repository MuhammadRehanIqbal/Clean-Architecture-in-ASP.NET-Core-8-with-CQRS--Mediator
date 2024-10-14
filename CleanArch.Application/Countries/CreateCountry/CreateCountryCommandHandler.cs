using CleanArch.Application.Authentication.Commands.Register;
using CleanArch.Application.Common.Interfaces.Persistence;
using CleanArch.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;
        public CreateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country
            {
                Iso = request.Iso,
                Name = request.Name,
                PhoneCode = request.PhoneCode
            };

            return await _countryRepository.CreateCountry(country) != null;

        }
    }
}
