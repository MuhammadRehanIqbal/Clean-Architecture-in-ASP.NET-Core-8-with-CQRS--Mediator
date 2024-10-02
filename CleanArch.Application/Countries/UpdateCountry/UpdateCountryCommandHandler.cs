using CleanArch.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.UpdateCountry
{ 
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;

        public UpdateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            // Get the country to be updated
            var existingCountry = await _countryRepository.GetCountryById(command.Id);
            if (existingCountry == null)
                throw new Exception("Country not found");  // Handle this according to your error handling strategy

            // Update the country properties
            existingCountry.Iso = command.Iso;
            existingCountry.Name = command.Name;
            existingCountry.PhoneCode = command.PhoneCode;

            // Call the repository to update the country
            await _countryRepository.UpdateCountry(existingCountry);

            return true;
            // Since you don't want to return anything, just return Unit.Value/////
            // Unit is the MediatR's way to represent a void return type-
        }
    }

}
