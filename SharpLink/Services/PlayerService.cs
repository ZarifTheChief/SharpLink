using SharpLink.DB;
using response = SharpLink.Models.Response;
using request = SharpLink.Models.Request;
using SharpLink.Models;

namespace SharpLink.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ISqlDataAccess _dataAccess;
        public PlayerService(ISqlDataAccess dataAccess) 
        { 
            _dataAccess = dataAccess;
        }

        public List<response.Player> GetPlayers()
        {
            return _dataAccess.GetPlayers();
        }

        public response.Player GetPlayer(string lastName, string position, int age, string ageRange)
        {
            var range = ageRange.Split("-");
            int ageMin;
            int ageMax;
            var request = new request.Player
            {
                LastName = lastName,
                Position = position,
                Age = age,
                AgeMin = int.TryParse(range[0], out ageMin) ? ageMin : 0,
                AgeMax = int.TryParse(range[1], out ageMax) ? ageMax : 0,
            };

            return _dataAccess.GetPlayer(request);
        }
    }
}
