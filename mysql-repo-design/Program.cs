using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using NLog;

namespace mysql_repo_design
{
    public class Program
    {

        public static MySqlConnection Conn;
        
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            const string connectString = "server=127.0.0.1;" +
                                         "uid=root;" +
                                         "pwd=test;" +
                                         "database=test;";
            
            logger.Info("MYSQL Connection: ", connectString);

            try
            {
                Conn = new MySqlConnection {ConnectionString = connectString};
                Conn.Open();
                logger.Info("MYSQL Connection: Success!");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}