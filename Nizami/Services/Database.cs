using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
namespace Nizami.Services
{
    public class Database
    {
        private static SqlConnection? connection;
        public Database()
        {
            var configuration = getConfiguration();
            //creates a database connection
            connection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Nizami").Value);
        }

        //returns the configuration data in appsettings.json
        public static IConfigurationRoot getConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //opens connection to database
        public void open()
        {
            connection?.Open();    
        }

        //closes connection to database
        public void close()
        {
            connection?.Close();
        }
    }
}
