namespace SharpLink.Models.Response
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public int Age { get; set; }

        public string Stub { get; set; } = null!;

        public int AgeDiff { get; set; }
    }
}