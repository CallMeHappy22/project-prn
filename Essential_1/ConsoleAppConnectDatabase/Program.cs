using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WinFormsApp1
{
    internal static class Program
    {
        //Get connection string from appsettings.json
        static string GettConnectString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConnection = config["ConnectionString:Cinema"];
            return strConnection;
        }//end GettConnectionString

        static void ViewProducts()
        {
            DbProviderFactory factory = SqlClientFactory.Instance;
            //get the connecion object
            using DbConnection connection = factory.CreateConnection();
            if (connection == null)
            {
                Console.WriteLine($"Unable to create the connection object.");
                return;
            }
            connection.ConnectionString = GettConnectString();
            connection.Open();
            //Make command object
            DbCommand command = factory.CreateCommand();
            if (command == null)
            {
                Console.WriteLine($"Unable to create the command object.");
                return;
            }
            command.Connection = connection;
            command.CommandText = "select * from Films";
            //Print out data with data reader.
            using DbDataReader dataReader = command.ExecuteReader();
            Console.WriteLine("----------------Book List----------------");
            while (dataReader.Read())
            {
                Console.WriteLine($"FilmID: {dataReader["FilmID"]} Tile: {dataReader["Title"]}");
            }
        }

        static void Main()
        {
            ViewProducts();
            Console.ReadLine();
        }
    }
}
