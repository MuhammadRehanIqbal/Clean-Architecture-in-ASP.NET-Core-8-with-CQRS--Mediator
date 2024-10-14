using CleanArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Common.Interfaces.Persistence
{
    public interface ICountryRepository
    {
        Task<Country?> CreateCountry(Country entity);
        Task<List<Country>> GetAllCountry();
        Task<Country> GetCountryById(int Id);
        Task UpdateCountry(Country country);
        Task DeleteCountry(int Id);

    } 
}
