namespace Mastermind.DTOs
{
    public class ReponseTentative
    {
        public int BienPlaces { get; set; }

        public int MalPlaces { get; set; }

        public int TentativesRestantes { get; set; }

        public string Etat { get; set; } = string.Empty;
    }
}