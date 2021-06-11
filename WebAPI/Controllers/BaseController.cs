using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected AppRepository app;
        public BaseController(IDbConnection connection)
        {
            connection.Open();
            app = new AppRepository(connection);
            /*try
            {
                connection.Open();
                app = new AppRepository(connection);
            }
            finally
            {
                connection.Close();
            }*/

        }
        public BaseController()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            IDbConnection connection = new SqlConnection(configuration.GetConnectionString("shop"));
            /*try
            {
                connection.Open();
                app = new AppRepository(connection);
            }
            finally
            {
                connection.Close();
            }*/
            connection.Open();
            app = new AppRepository(connection);
        }
    }
}
