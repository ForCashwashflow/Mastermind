namespace Mastermind.Models
{
    public class Tentative
    {
        public List<int> Proposition { get; set; } = new();

        public int BienPlaces { get; set; }

        public int MalPlaces { get; set; }
    }
}