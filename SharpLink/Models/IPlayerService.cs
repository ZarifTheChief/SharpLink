using SharpLink.Models.Response;

namespace SharpLink.Models
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();

        Player GetPlayer(string lastName, string position, int age, string ageRange);
    }
}
