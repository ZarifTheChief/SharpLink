namespace SharpLink.Models.Request
{
    public class Player
    {
        public string LastName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public int Age { get; set; }

        public int AgeMin { get; set; }

        public int AgeMax { get; set; }
    }
}
