using Microsoft.Data.Sqlite;
using System.Data;
using response = SharpLink.Models.Response;
using request = SharpLink.Models.Request;

namespace SharpLink.Models
{
    public interface ISqlDataAccess
    {
        List<response.Player> GetPlayers();

        response.Player GetPlayer(request.Player player);
    }
}
