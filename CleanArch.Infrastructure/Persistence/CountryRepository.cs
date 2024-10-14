using CleanArch.Application.Common.Interfaces.Persistence;
using CleanArch.Core.Entities;
using CleanArch.Infrastructure.DbContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperContext _context;

        public CountryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateCountry(Country country)
        {

            using (var db = _context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Iso", country.Iso);
                    parameters.Add("@Name", country.Name);
                    parameters.Add("@PhoneCode", country.PhoneCode);

                    await db.ExecuteAsync("sp_CeareCountry", parameters, commandType: CommandType.StoredProcedure);

                    // Assuming the user entity is returned with necessary details or just return the user object
                    return country;
                }
                catch (Exception ex)
                {
                    throw; // Rethrow or handle the exception as needed
                }
            }
        }
        public async Task<List<Country>> GetAllCountry()
        {
            using (var db = _context.CreateConnection())
            {
                var countries = await db.QueryAsync<Country>("sp_GetAllCountries", commandType: CommandType.StoredProcedure);
                return countries.ToList();
            }
        }
        public async Task<Country> GetCountryById(int Id)
        {
            using (var db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                return await db.QuerySingleOrDefaultAsync<Country>("sp_GetCountryById", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task UpdateCountry(Country country)
        {
            using (var db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", country.Id);
                parameters.Add("@Iso", country.Iso);
                parameters.Add("@Name", country.Name);
                parameters.Add("@PhoneCode", country.PhoneCode);

                await db.ExecuteAsync("sp_UpdateCountry", parameters, commandType: CommandType.StoredProcedure);
                // No return value; execution is just performed.
            }
        }

        public async Task DeleteCountry(int Id)
        {
            using (var db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id); // Assuming the stored procedure requires Id as a parameter

                await db.ExecuteAsync("sp_DeleteCountry", parameters, commandType: CommandType.StoredProcedure);
<<<<<<< HEAD
                // No need to return anything since the method is void//
=======
                // No need to return anything since the method is void--
>>>>>>> CQRS-Mediatorr
            }
        }


    }
}
