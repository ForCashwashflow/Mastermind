namespace Mastermind.DTOs
{
    public class TentativeHistorique
    {
        public List<int> Proposition { get; set; } = new();

        public int BienPlaces { get; set; }

        public int MalPlaces { get; set; }
    }
}