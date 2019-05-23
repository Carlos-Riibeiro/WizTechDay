using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WizTechDay.Infra.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection WizTechDayConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("wizTechDay"));
            }
        }
    }
}
