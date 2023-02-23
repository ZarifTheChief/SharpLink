using Microsoft.AspNetCore.Mvc;
using SharpLink.Models;
using SharpLink.Models.Response;
using SharpLink.Services;

namespace SharpLink.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }

        [HttpGet, Route("players")]
        public IEnumerable<Player> GetPlayers()
        {
            return _playerService.GetPlayers();
        }

        [HttpGet, Route("/{lastName}/{position}/{age}/{ageRange}")]
        public Player GetPlayer(string lastName, string position, int age, string ageRange)
        {
            return _playerService.GetPlayer(lastName, position, age, ageRange);
        }
    }
}