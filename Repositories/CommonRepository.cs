using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace WebAPI.Repositories
{
    public class CommonRepository
    {
        protected NpgsqlConnection conn;

        public CommonRepository()
        {
            IConfiguration myConfig = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


            conn = new NpgsqlConnection(myConfig.GetConnectionString("DefaultConnection"));
        }
    }
}