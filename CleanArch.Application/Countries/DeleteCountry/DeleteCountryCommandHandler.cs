using CleanArch.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly ICountryRepository _countryrepository; 

        public DeleteCountryCommandHandler(ICountryRepository countryrepository)
        {
            _countryrepository = countryrepository; 
        }

        public async Task<bool> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            var todoItem = await _countryrepository.GetCountryById(command.Id);
            if (todoItem == null) return false;

            await _countryrepository.DeleteCountry(command.Id); 
            return true;

        }
    }
}
