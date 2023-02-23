using Dapper;
using Microsoft.Data.Sqlite;
using SharpLink.Models;
using System.Data;
using request = SharpLink.Models.Request;
using response = SharpLink.Models.Response;

namespace SharpLink.DB
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public List<response.Player> GetPlayers()
        {
            using (IDbConnection sql = new SqliteConnection(LoadConnectionString()))
            {
                var output = sql.Query<response.Player>("SELECT * from Player", new DynamicParameters());
                return output.ToList();
            }
        }

        public response.Player GetPlayer(request.Player player)
        {
            var query = "SELECT Id, FirstName, LastName, Position, Age, Stub, AgeDiff from Player WHERE 1=1";
            if (!string.IsNullOrEmpty(player.LastName))
            {
                query += " and LastName = @LastName";
            }
            if (!string.IsNullOrEmpty(player.Position))
            {
                query += " and Position = @Position";
            }
            if(player.Age > 0) 
            {
                query += " and Age = @Age";
            } 
            if(player.AgeMax > 0 & player.AgeMin > 0)
            {
                query += " and Age < @Max and Age > @Min";
            }
            using (IDbConnection sql = new SqliteConnection(LoadConnectionString()))
            {
                var output = sql.Query<response.Player>(query);
                return output.FirstOrDefault();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return "Data Source=.\\SharpLinkDB.db;";
        }
    }
}
