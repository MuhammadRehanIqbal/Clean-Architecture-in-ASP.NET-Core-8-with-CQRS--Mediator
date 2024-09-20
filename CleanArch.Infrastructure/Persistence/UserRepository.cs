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

    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Username", user.Username);
                    parameters.Add("@Password", user.Password);
                    parameters.Add("@FirstName", user.FirstName);
                    parameters.Add("@LastName", user.LastName);
                    parameters.Add("@Device", user.Device);
                    parameters.Add("@IpAddress", user.IpAddress);

                    await db.ExecuteAsync("sp_Add_CQRSUsers", parameters, commandType: CommandType.StoredProcedure);

                    // Assuming the user entity is returned with necessary details or just return the user object
                    return user;
                }
                catch (Exception ex)
                { 
                    throw; // Rethrow or handle the exception as needed
                }
            }
        }
        public async Task<Balance> GetBalance(string username)
        {
            using (var db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", username);
                return await db.QuerySingleOrDefaultAsync<Balance>("sp_Get_CQRSUsersBlance", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Email", email); 
                    parameters.Add("@LoginTime", DateTime.UtcNow);
                    return await db.QuerySingleOrDefaultAsync<User>("sp_Get_CQRSUsersByEmail", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception details as needed
                    // For example: _logger.LogError(ex, "Error retrieving user by email");
                    throw; // Rethrow or handle the exception as needed
                }
            }
        }
    }
}

