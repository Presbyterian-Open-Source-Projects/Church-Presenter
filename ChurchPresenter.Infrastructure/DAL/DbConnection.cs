using ChurchPresenter.Core.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ChurchPresenter.Infrastructure.DAL
{
    internal class DbConnection
    {


        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection($"Data Source={MediaService.GetDbPath()};Version=3;");
        }

        private static async Task CreateDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                await cnn.OpenAsync();
                await cnn.ExecuteAsync(InitialTablesCommands.CreateSongTable);
                await cnn.ExecuteAsync(InitialTablesCommands.CreateHymnMetaTable);
                await cnn.ExecuteAsync(InitialTablesCommands.CreateHymnTable);
            }
        }


        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


    }
}