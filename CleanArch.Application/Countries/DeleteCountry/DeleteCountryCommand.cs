using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Countries.DeleteCountry
{
    public record DeleteCountryCommand(int Id) : IRequest<bool>;
}
