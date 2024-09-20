using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.DbContext
{
    public class DapperContext
    {
        private readonly DapperSettings _dapperSettings;

        public DapperContext(IOptions<DapperSettings> DapperSettings)
        {
            _dapperSettings = DapperSettings.Value;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_dapperSettings.SqlServer);

    }



}
